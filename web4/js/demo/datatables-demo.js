// Call the dataTables jQuery plugin
$(document).ready(function() {
    $('#dataTable').DataTable({
        "oLanguage": {
            "sSearch": ":بحث"
        },
        "language": {
            "info": "عرض _START_ الى _END_ من _TOTAL_ مدخلات",
            "infoEmpty": "Showing 0 to 0 of 0 entries",
            "lengthMenu": "عرض _MENU_ مدخلات",
            "paginate": {
                "first": "الأول",
                "last": "الأخير",
                "next": "التالي",
                "previous": "السابق"
            },
        }
    });
});
