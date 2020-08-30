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
                "data": "name", "render": function (data, type, row, meta) {
                    return "<a href='" + row.rtsp + "' class='btn btn-info'>View</a>";
                }
            }
        ]

    });

});
