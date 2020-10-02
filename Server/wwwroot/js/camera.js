$(document).ready(function () {
    var table = $("#table-camera").DataTable({
        "paging": false,
        "processing": false, 
        "serverSide": true, 
        "filter": false,  
        "ajax": {
            "url": "/Home/CameraTable",
            "type": "POST",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "name": "Name", "autoWidth": true },
            {
                "data": null, "render": function (data, type, row, meta) {
                    return "<a href='" + row.main + "' class='btn btn-info'>Основной</a>";
                }
            },
            {
                "data": null, "render": function (data, type, row, meta) {
                    return "<a href='" + row.sub + "' class='btn btn-info'>Доп.</a>";
                }
            }
        ]

    });

});
