var app = app || {};

app.utils = (function () {
    function formatDate(dateString) {
        var dateStringParts = dateString.split('T');
        var date = new Date(dateStringParts[0]);
        var time = new Date(dateStringParts[1]);
        var dateString = '',
            dateParts = [date.getDate(), date.getMonth(), date.getFullYear()];

        dateString += dateParts.join('-');
        
        return dateString;
    }

    function loadOptions(url, propertyText, propertyValue, container) {
        var selectElement = $(container);
        app.ajaxRequester.get(url).then(function (data) {
            data.forEach(function (category) {
                var optionTemplate = $('<option></option>');
                optionTemplate.attr('value', category[propertyValue]);
                optionTemplate.text(category[propertyText]);
                selectElement.append(optionTemplate);
            });
        }, function (err) {
            console.error(err);
        });
    }

    function getFormData(selector) {
        var form = $(selector);
        var data = {};

        $.each(form.children(), function (index, element) {
            var formEl = $(element);
            var formElName = formEl.attr('name');
            if (formElName) {
                var formElValue = formEl.val();
                if (formElName === 'Tags') {
                    formElValue = formElValue.split(',').filter(Boolean);
                }
                data[formElName] = formElValue;
            }
        });
        return data;
    }

    return {
        formatDate: formatDate,
        loadOptions: loadOptions,
        getFormData: getFormData
    };
})();