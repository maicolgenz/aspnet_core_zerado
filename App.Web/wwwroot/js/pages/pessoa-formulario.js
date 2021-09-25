$(document).ready(function () {
    Mascaras();
    loadCidades();
});

function loadCidades() {
    CidadeListaCidades('').then(function (data) {
        data.forEach(obj => {
            $('#cidadeId').append('<option value="'+obj.id+'">'+obj.nome+'</option>');
        });
        $('#cidadeId').select2();

    });
}

function salvar() {
    let obj = {
        nome: ($("[name='nome']").val() || ''),
        cidadeId: ($("[name='cidadeId']").val() || ''),
        peso: (parseInt($("[name='peso']").val()) || 0),
        dataNascimento: ($("[name='dataNascimento']").val() || '')
    };
    PessoaSalvar(obj).then(function () {
        window.location.href = '/pessoa';
    }, function (err) {
        alert(err);
    });
}

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