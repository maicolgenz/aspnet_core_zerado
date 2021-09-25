$(document).ready(function () {
    $('#busca').keypress(function (e) {
        if (e.which === 13) {
            load();
        }
    });
    load();
    $('[name="telefone"]').mask('9999-9999');

    Mascaras();
});

function load() {
    let nome = $('[name="nome"]').val();
    let pesoMaiorQue = ($('[name="pesoMaiorQue"]').val() || 0);
    let pesoMenorQue = ($('[name="pesoMenorQue"]').val() || 0);
    PessoaListaPessoas(nome, pesoMaiorQue, pesoMenorQue).then(function (data) {
        $('#table tbody').html('');
        data.forEach(obj => {
            $('#table tbody').append('' +
                '<tr id="obj-' + obj.id + '">' +
                '<td>' + (obj.nome || '--') + '</td>' +
                '<td>' + (obj.peso || '--') + '</td>' +
                '<td>' + (moment(obj.dataNascimento).format('DD/MM/YYYY') || '--') + '</td>' +
                '<td>' + (obj.cidade.nome || '--') + '</td>' +
                '<td>' + (obj.ativo === true ? 'Ativo' : 'Inativo') + '</td>' +
                '</tr>');
        });
    });
}

//$("#telefone").inputmask({
//    mask: "(\(?\d{2}\)?\s)?(\d{4,5}\-\d{4})",
//});]


function Mascaras() {
    $("[data-mascara='date']").each(function () { $(this).mask('00/00/0000'); });
    $("[data-mascara='datetime']").each(function () { $(this).mask('00/00/0000 00:00'); });
    $("[data-mascara='cep']").each(function () { $(this).mask('00000-000'); });
    $("[data-mascara='phone']").each(function () { $(this).mask('(00) 00000-0000'); });
    $("[data-mascara='number']").each(function () { $(this).mask('0#'); });
    $("[data-mascara='decimal']").each(function () { $(this).mask('000.000.000.000.000,00', { reverse: true }); });
    $("[data-mascara='cpf']").each(function () { $(this).mask('000.000.000-00', { reverse: true }); });
    $("[data-mascara='cnpj']").each(function () { $(this).mask('00.000.000/0000-00', { reverse: true }); });
    $("[data-mascara='cpfCnpj']").each(function () {
        var options = {
            onKeyPress: function (cpf, ev, el, op) {
                var masks = ['000.000.000-000', '00.000.000/0000-00'];
                $(this).mask(cpf.length > 14 ? masks[1] : masks[0], op);
            }
        };
        $(this).length > 11 ? $(this).mask('00.000.000/0000-00', options) : $(this).mask('000.000.000-00#', options);
    });
}