$(document).ready(function () {
    load();
});

function load() {
    CidadeListaCidades().then(function (data) {
        data.forEach(obj => {
            $('#table tbody').append('' +
                '<tr id="obj-' + obj.id + '">' +
                '<td>' + (obj.cep || '--') + '</td>' +
                '<td>' + (obj.nome || '--') + '</td>' +
                '<td>' + (obj.uf || '--') + '</td>' +
                '</tr>');
        });
    });
}

