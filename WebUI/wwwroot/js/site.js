//Funciones para el Select2
function Select2AjaxOptions(url) {
    return {
        url: url,
        dataType: 'json',
        delay: 250,
        data: function (params) {
            return {
                q: params.term
            };
        },
        processResults: function (data) {
            return {
                results: data
            };
        }
    };
}

function MyAjaxSelect2(selector, url, placeholder) {
    $(selector).select2({
        //minimumInputLength: 3,
        theme: 'classic',
        language: 'es',
        //width: '280px',
        placeholder: placeholder,
        allowClear: true,
        ajax: Select2AjaxOptions(url)
    });
}

function MySelect2(selector, placeholder) {
    $(selector).select2({
        language: 'es',
        placeholder: placeholder,
        allowClear: true,
    });
}