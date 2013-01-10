var request;

describe('Autocomplete', function () {

    beforeEach(function() {
        jasmine.Ajax.useMock();

        request = mostRecentAjaxRequest();
    });

    it('Verifica parametro Url', function () {
        
        var customAutocomplete = $().customAutocomplete('/Home/PesquisaServicos');

        expect(customAutocomplete.options('url')).toEqual('/Home/PesquisaServicos');
    });

    it('Verifica se a propriedade source está retornando', function() {

        var mock = $("<input type='text' />");

        var customAutocomplete = $(mock).customAutocomplete('/Home/PesquisaServicos');

        mock.val('teste').trigger('change');
        
        expect(typeof customAutocomplete.source).toBe('function');
    });
});