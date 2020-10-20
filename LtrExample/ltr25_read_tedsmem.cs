using ltrModulesNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LtrExample
{
    public class ltr25_read_tedsmem
    {
        /* Номер слота в крейте, где вставлен модуль */
        const int SLOT = 1;
        const int CH_NUM = 2;

        public static int _Main(string[] args)
        {
            /* LTR25_Init() вызывается уже в конструкторе */
            ltr25api hltr25 = new ltr25api();
            /* отрываем модуль. есть вариант как с только со слотам, так и с серийным крейта и слотом 
             *  + полный */
            _LTRNative.LTRERROR err = hltr25.Open(SLOT);
            if (err != _LTRNative.LTRERROR.OK)
            {
                Console.WriteLine("Не удалось открыть модуль. Ошибка {0}: {1}",
                    err, ltr25api.GetErrorString(err));
            }
            else
            {
                /* выводим информацию из hltr25.ModuleInfo */
                Console.WriteLine("Модуль открыт успешно. Информация о модуле: ");
                Console.WriteLine("  Название модуля  = {0}", hltr25.ModuleInfo.Name);
                Console.WriteLine("  Серийный номер   = {0}", hltr25.ModuleInfo.Serial);
                Console.WriteLine("  Версия FPGA      = {0}", hltr25.ModuleInfo.VerFPGA);
                Console.WriteLine("  Версия PLD       = {0}", hltr25.ModuleInfo.VerPLD);
                Console.WriteLine("  Ревизия платы    = {0}", hltr25.ModuleInfo.BoardRev);
                Console.WriteLine("  Темп. диапазон   = {0}", hltr25.ModuleInfo.Industrial ? "Индустриальный" : "Коммерческий");


                err = hltr25.SetSensorsPowerMode(ltr25api.SensorsPowerModes.TEDS);
                if (err != _LTRNative.LTRERROR.OK)
                {
                    Console.WriteLine("Не удалось перевести  модуль в режим чтения информации из памяти TEDS. Ошибка {0}: {1}",
                        err, ltr25api.GetErrorString(err));
                }
                else
                {
                    ltr25api.TEDS_NODE_INFO info;
                    err = hltr25.TEDSNodeDetect(CH_NUM, out info);
                    if (err != _LTRNative.LTRERROR.OK)
                    {
                        Console.WriteLine("Не удалось определить узел TEDS. Ошибка {0}: {1}",
                            err, ltr25api.GetErrorString(err));
                    }
                    else
                    {
                        Console.WriteLine("Узел TEDS канала {0}:", CH_NUM + 1);
                        Console.WriteLine("   Тип микросхемы     = {0}", info.DevFamilyCode);
                        Console.WriteLine("   Размер памяти      = {0}", info.MemorySize);
                        Console.WriteLine("   Размер данных TEDS = {0}", info.TEDSDataSize);


                        byte[] tedsdata = new byte[info.TEDSDataSize];
                        uint rdsize;
                        err = hltr25.TEDSReadData(CH_NUM, tedsdata, (uint)tedsdata.Length, out rdsize);
                        if (err != _LTRNative.LTRERROR.OK)
                        {
                            Console.WriteLine("Не удалось прочитать память узла TEDS. Ошибка {0}: {1}",
                                err, ltr25api.GetErrorString(err));
                        }

                        byte[] memdata = new byte[info.MemorySize];


                        err = hltr25.TEDSMemoryRead(CH_NUM, 0, memdata, (uint)memdata.Length, 0);
                        if (err != _LTRNative.LTRERROR.OK)
                        {
                            Console.WriteLine("Не удалось прочитать память узла TEDS. Ошибка {0}: {1}",
                                err, ltr25api.GetErrorString(err));
                        }
                        else
                        {
                            string fileName = "tedsdata.bin";
                            using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
                            {
                                writer.Write(memdata);
                            }
                        }
                    }
                }
                hltr25.Close();
            }

            return (int)err;
        }
    }
}
