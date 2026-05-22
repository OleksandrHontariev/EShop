let ProductList = (function ($) {
    'use strict';

    let filterApiUrl = null;

    function enableDisableFilterDropdown($fsearch, enable) {
        if (enable) {
            $fsearch.prop('disabled', false);
        } else {
            $fsearch.prop('disabled', true);
        }
    }

    function sendForm(inputElem) {
        let form = $(inputElem).parents('form');
        form.submit();
    }

    function loadFilterValueDropdown(filterByValue, filterValue) {
        filterValue = filterValue || '';
        let $fsearch = $('#filter-value-dropdown');
        enableDisableFilterDropdown($fsearch, false);
        if (filterByValue !== 'NoFilter') {
            $.ajax({
                url: filterApiUrl,
                data: { FilterBy: filterByValue }
            })
                .done(function (indentAndResult) {
                    $fsearch
                        .find('option')
                        .remove()
                        .end()
                        .append($('<option></option>')
                            .attr('value', '')
                            .text('Select filter...')
                        );

                    indentAndResult.result.forEach(function (arrayElem) {
                        $fsearch
                            .append($('<option></option>')
                            .attr('value', arrayElem.value)
                            .text(arrayElem.text));
                    });

                    $fsearch.val(filterValue);
                    enableDisableFilterDropdown($fsearch, true);
                })
                .fail(function () {
                    alert('error');
                });
        }
    }

    return {
        initialize: function (filterByValue, filterValue, exFilterApiUrl) {
            filterApiUrl = exFilterApiUrl;
            loadFilterValueDropdown(filterByValue, filterValue);
        },
        sendForm: function (inputElem) {
            sendForm(inputElem);
        },
        filterByHasChanged: function (filterElem) {
            let filterByValue = $(filterElem).find(':selected').val();
            loadFilterValueDropdown(filterByValue);
            // if default value (not selected) - reload page
            if (filterByValue === '0') {
                sendForm(filterElem);
            }
        },
        loadFilterValueDropdown: function (filterByValue, filterValue) {
            loadFilterValueDropdown(filterByValue, filterValue);
        }
    };
})(window.jQuery);