$(function () {
    window.SenhasHub = {
        _hub: $.connection.senhasHub,
        _senha: 0
    };

    SenhasHub.Server = function () {
        this.hub = SenhasHub._hub;

        this.proximaSenha = function () {
            this.hub.server.proximaSenha();
        };
    };
    
    SenhasHub.Cliente = function () {

        var hub = SenhasHub._hub;

        this.senhaAtual = ko.observable(SenhasHub._senha);

        var senhaAtual = this.senhaAtual;

        this.proximaSenha = function () {
            hub.server.proximaSenha();
        };

        this.init = function () {
            hub.server.obterSenhaAtual();
        };
        
        hub.client.senhaAtual = function (senha) {
            senhaAtual(senha);
        };

        return {
            proximaSenha: this.proximaSenha,
            senhaAtual: this.senhaAtual,
            init: this.init
        };
    };
});