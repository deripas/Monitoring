using api.dto;
using model.camera;

namespace model.nvr
{
    public class NvrController
    {
        private NvrModel model;

        public NvrController(NvrInfo nvr)
        {
            this.model = new NvrModel(nvr);
            model.Login();
        }

        internal CameraController Camera(int chanel)
        {
            CameraController camera = new CameraController(model, chanel);
            return camera;
        }

        internal void Disconnect()
        {
            model.Logout();
        }
    }
}
