var chart;

$(function () {

    var defaultOptions = {
        chart: {
            renderTo: 'charts-container',
            type: 'line',
            marginRight: 130,
            marginBottom: 25
        },
        title: {
            text: 'Gráfico',
            x: -20 //center
        },
        subtitle: {
            text: 'Connect Informática',
            x: -20
        },
        xAxis: {
            categories: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez']
        },
        yAxis: {
            title: {
                text: 'Quantidade'
            },
            plotLines: [{
                value: 0,
                width: 1,
                color: '#808080'
            }]
        },
        tooltip: {
            formatter: function() {
                return '<b>' + this.series.name + '</b><br/>' +
                    this.x + ': ' + this.y;
            }
        },
        legend: {
            layout: 'vertical',
            align: 'right',
            verticalAlign: 'top',
            x: -10,
            y: 100,
            borderWidth: 0
        },
        series: []
    };

    function Serie(name, data) {
        this.name = ko.observable(name);
        this.data = ko.observableArray(data);
    }

    window.Monitor = {
        hub: $.connection.highchartsHub
    };

    window.Monitor.Server = function () {

        this.hub = window.Monitor.hub;

        this.numeroProposta = ko.observable();

        this.salvarProposta = function () {
            this.hub.server.teste(this.numeroProposta());
        };
    };

    window.Monitor.Client = function (options) {

        options = options || {};

        this.hub = window.Monitor.hub;

        this.series = ko.observableArray([]);

        this.chartOptions = $.extend(false, defaultOptions, {
            chart: {
                renderTo: 'charts-container',
                type: 'line'
            },
            title: {
                text: 'Proposta Comercial - Situação'
            },
            xAxis: {
                categories: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez']
            }
        });
        
        this.chart = new options.chart(this.chartOptions) || {};

        var series = this.series;
        var chart = this.chart;
        
        series.add = function (value) {
            if (value instanceof Array)
                for (var i = 0; i < value.length; i++)
                    series.add(value[i]);
            else
                chart.addSeries({ name: value.name(), data: value.data() });
        };

        series.subscribe(function(value) {
            series.add(value);
        });

        this.hub.client.addSerie = function (serie) {
            series.add(new Serie(serie.Name, serie.Data));
        };

        this.hub.client.setData = function (name, pos) {
            if (!name) return;
            for (var i = 0; i < chart.series.length; i++) {
                if (chart.series[i].name == name) {
                    var y = chart.series[i].yData[pos - 1];
                    chart.series[i].data[pos - 1].update(y += 1);
                    break;
                }
            }
        };

        this.hub.client.populateSeries = function (serieArray) {
            var mappedTasks = $.map(serieArray, function(item) {
                return new Serie(item.Name, item.Data);
            });
            series(mappedTasks);
        };

        this.init = function() {
            this.hub.server.getSeries();
        };
        
        this.typeChart = ko.observable();

        this.aplicar = function () {
            chart.options.chart.type = this.typeChart();
            chart.redraw();
        };
    };
    
});