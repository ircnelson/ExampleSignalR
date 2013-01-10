(function ($) {

    $.fn.customAutocomplete = function(url, opts) {

        var _that = this;
        var _cache = { };
        var _defaultOptions = {
            url: url
            , minLength: 4
            , source: function (request, response) {
                var term = request.term;
                if (term in _cache) {
                    response(_cache[term]);
                    return;
                }

                $.getJSON(window.appUrl + url, request, function (data, status, xhr) {
                    _cache[term] = data;
                    response(data);
                });
            }
        };

        var attrs = $.extend(true, opts, _defaultOptions);
        this._autocomplete = $(_that).autocomplete(attrs);
        
        this._options = function (attr) {
            return attrs[attr];
        };

        return {
            options: this._options
            , source: this._autocomplete.autocomplete('option', 'source')
            , plugin: this._autocomplete.autocomplete()
        };
    };

})(jQuery)