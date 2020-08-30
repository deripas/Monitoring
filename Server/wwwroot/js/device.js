$(document).ready(function () {
    var table = $("#table-divice").DataTable({
        "paging": false,
        "processing": false, 
        "serverSide": true, 
        "filter": false,  
        "ajax": {
            "url": "/Home/DeviceTable",
            "type": "POST",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "name": "Name", "autoWidth": true },
            { "data": "value", "name": "Status", "autoWidth": true },
            {
                "data": null, "render": function (data, type, row, meta) {
                    return "<a href='" + row.rtsp + "' class='btn btn-info'>View</a>";
                }
            }
        ]

    });


    setInterval(function () {
        table.ajax.reload();
    }, 1000);
});

