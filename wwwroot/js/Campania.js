////var dataTable;

////$(document).ready(function () {
////    loadDataTable();
////});
////function loadDataTable() {
////    dataTable = $('#tblData').DataTable({
////        "ajax": {
////            "url": "/Campania/ObtenerTodos"
////        },
////        "colums": {
////            { "data": "Nombres", "width": "10%" },
////            { "data": "FechaInicio", "width": "10%" },
////            { "data": "FechaFinalizacion", "width": "10%" },
////            { "data": "Descripcion", "width": "30%" },
////            { "data": "Estado",
////                "reder": function (data) {
////                    if (data == true) {
////                        return "Activo";
////                    } else {
////                        return "Inactivo";
////                    }
////                }, "width": "20%"}
////        }
////    });
////}