var HighchartsCustom = { };

$(function() {
    HighchartsCustom.defaultOptions = {
        chart: {
            renderTo: 'chart-container',
            type: 'line'
        },
        
        credits: {
            enabled: false
        },
        
        lang: {
            loading: 'Carregando...'
        },

        tooltip: {
            formatter: function () {
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

    HighchartsCustom.create = function(option, url, onSuccess) {
        var myOptions = $.extend(false, HighchartsCustom.defaultOptions, option);

        var _map = function(chartOjb, data) {
            $.map(data, function(item) { chartOjb.addSeries(item); });
        };

        var carregarGrafico = function (chartOjb, url, onSuccess) {
            $.ajax({
                url: window.urlRoot + url,
                type: 'POST',
                dataType: 'json',
                success: function (data) {
                    if (typeof onSuccess == 'function')
                        onSuccess(chartOjb, data);
                    else
                        _map(chartOjb, data);
                }
            });
        };

        var chartOjb = new Highcharts.Chart(myOptions);
        
        $.when(chartOjb, carregarGrafico(chartOjb, url, onSuccess)).then(function () {
            chartOjb.showLoading();
        }).done(function () {
            chartOjb.hideLoading();
        });

        return chartOjb;
    };
});