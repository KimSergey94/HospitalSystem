$(function(){
    $("#jqGPatients").jqGrid({
        url: "/home/GetPatientsJSON",
        datatype: "json",
        mtype: "GET",
        width: "1278px",
        colNames: ['ID пациента', 'Имя', 'Фамилия', 'Отчество',
            'ИИН', 'Телефонный номер', 'Адрес проживания'],
        colModel: [
            { key: true, hidden: true, name: 'PatientId', index: 'PatientId', width: 115, align: "center", editable: true, stype: 'text', sortable: true },
            { key: false, name: 'FirstName', index: 'FirstName', width: 186, align: "center", editable: true, sortable: true },
            { key: false, name: 'LastName', index: 'LastName', width: 189, align: "center", editable: true, sortable: true },
            { key: false, name: 'Patronymic', index: 'Patronymic', width: 181, align: "center", editable: true, sortable: true },
            { key: false, name: 'IIN', index: 'IIN', width: 174, align: "center", editable: true, sortable: true },
            { key: false, name: 'PhoneNumber', index: 'PhoneNumber', width: 180, align: "center", editable: true, sortable: true },
            { key: false, name: 'Address', index: 'Address', width: 210, align: "center", editable: true, sortable: true }
        ],
        multiselect: false,
        caption: "Список Пациентов",
        pager: jQuery('#jqGridPager'),
        rowNum: 15,
        rowList: [10, 20, 30, 40],
        viewrecords: true,
        emptyrecords: 'Пациентов не было найдено для отображения',
        jsonReader: {
            root: "rows",
            page: "Страница",
            total: "total",
            records: "records",
            repeatitems: "false",
            id: 0
        }
    }).navGrid('#jqGridPager', {
        edit: true, edittext: "Изменить", add: true, addtext: "Добавить",
        del: true, deltext: "Удалить", search: true, searchtext: "Поиск", refresh: true
    },
        {
            //edit options
            zIndex: 100,
            url: '/Home/EditPatient',
            closeOnEscape: true,
            closeAfterEdit: true,
            recreateForm: true,
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            }
        },
        {
            //add options
            zIndex: 100,
            url: '/Home/CreatePatient',
            closeOnEscape: true,
            closeAfterEdit: true,
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            }
        },
        {
            //delete options
            zIndex: 100,
            url: '/Home/DeletePatient',
            closeOnEscape: true,
            closeAfterEdit: true,
            recreateForm: true,
            message: "Вы действительно хотите удалить запись пациента?",
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            }
        });
});