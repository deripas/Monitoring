$(document).ready(function () {
    var table = $("#table-divice").DataTable({
        "paging": false,
        "processing": false, 
        "serverSide": true, 
        "filter": false,  
        "ajax": {
            "url": $("#url").val(),
            "type": "POST",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "name": "Name", "autoWidth": true },
            {
                "data": "value",
                "render": function (data, type, row, meta) {
                    if (row.enable) {
                        if (row.alert)
                            return "<div class=\"dev-alarm\">" + data + "</div>";
                        else
                            return "<div class=\"dev-ok\">" + data + "</div>";
                    } else {
                        return "<div class=\"dev-disable\">" + data + "</div>";
                    }
                }
            },
            {
                "data": null,
                "render": function (data, type, row, meta) {
                    return "<a href='" + row.main + "' class='btn btn-info'>Основной</a>";
                }
            },
            {
                "data": null,
                "render": function (data, type, row, meta) {
                    return "<a href='" + row.sub + "' class='btn btn-info'>Доп.</a>";
                }
            }
        ]

    });


    setInterval(function () {
        table.ajax.reload();
    }, 1000);
});

