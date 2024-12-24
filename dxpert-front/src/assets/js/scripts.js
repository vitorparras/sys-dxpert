$(document).jQuery(function() {
    var quantidadeFilhos1 = 1;
    var quantidadeFilhos2 = 1;

    $("#formulario .form .selecione label").click(function() {
        $("#formulario .form .selecione label").removeClass("selecionado");
        $(this).addClass("selecionado");
    });

    $(".add-dados-filho").click(function() {
        var texto =
            '<div class="info-filho"> ' +
            "<label> " +
            '<input type="text"  name="nomeFilho' +
            quantidadeFilhos1 +
            '" id="" placeholder="Nome do filho"> ' +
            "</label> " +
            "</div> " +
            "<div> " +
            "<label> " +
            '<input type="text" class="date" onfocus="(this.type=\'date\')" name="dtNascFilho' +
            quantidadeFilhos1 +
            '" id="" placeholder="Data de nascimento"> ' +
            "</label> " +
            "</div>";
        $("#bloco-add-filho").append(texto);
        quantidadeFilhos1 = quantidadeFilhos1 + 1;
    });

    $(".add-mais-beneficiario").click(function() {
        var texto =
            '<div class="info-filho">' +
            "<label>" +
            '<input type="text" name="nomeFilho' +
            quantidadeFilhos2 +
            '" id="" placeholder="Nome do filho">' +
            "</label>" +
            "</div>" +
            "<div>" +
            "<label>" +
            '<input type="text" class="date" onfocus="(this.type=\'date\')" name="dtNascFilho' +
            quantidadeFilhos2 +
            '" id="" placeholder="Data de nascimento">' +
            "</label>" +
            "</div>";
        $("#bloco-add-filho").append(texto);
        quantidadeFilhos2 = quantidadeFilhos2 + 1;
    });

    $(".forma-pagamento label").click(function() {
        $(".forma-pagamento label").removeClass("selecionado");
        $(this).addClass("selecionado");
        $(".div-forma-pagamento").removeClass("selecionado");
        var id = "#" + $(this).attr("data-id");
        $(id).addClass("selecionado");
    });

    $("#frmLogin").validate({
        rules: {
            emailLogin: {
                required: true,
                email: true,
            },
            password: {
                required: true,
            },
        },
        messages: {
            emailLogin: "E-mail obrigatório.",
            senhaLogin: "Senha obrigatório.",
        },
    });

    $("#frmCadastro").validate();

    jQuery.extend(jQuery.validator.messages, {
        required: "Campo obrigatório.",
        remote: "Por favor corrigir essa campo.",
        email: "E-mail inválido.",
        url: "URL inválida.",
        date: "Data inválida.",
        dateISO: "Por favor insira uma data válida (ISO).",
        number: "Número inválido.",
        digits: "Insira apenas digitos.",
        creditcard: "Cartão de crédito inválido.",
        equalTo: "Por favor insira o mesmo valor.",
        accept: "Por favor insira um valor válido.",
        maxlength: jQuery.validator.format(
            "O campo deve ter no máximo {0} caracteres."
        ),
        minlength: jQuery.validator.format(
            "O campo deve ter no mínimo {0} caracteres."
        ),
        rangelength: jQuery.validator.format(
            "O campo deve ter no mínimo {0} e no máximo {1} caracteres."
        ),
        range: jQuery.validator.format("Por favor entre um valor entre {0} e {1}."),
        max: jQuery.validator.format("Insira um valor menor ou igual a {0}."),
        min: jQuery.validator.format("Insira um valor maior ou igual a {0}."),
    });

    $(".date").mask("00/00/0000");
    $(".cep").mask("00000-000");

    $(".currency").maskMoney({
        decimal: ",",
        thousands: ".",
    });

    $("#FormAuto").ready(function() {
        setTimeout("", 30000);
        enviar();
    });

    function enviar() {
        var form = document.getElementById("FormAuto");
        if (form != null) {
            setTimeout("", 30000);
            form.submit();
        }
    }
});

$(document).jQuery(function() {
    $(".date").mask("00/00/0000");
    $(".time").mask("00:00:00");
    $(".date_time").mask("00/00/0000 00:00:00");
    $(".cep").mask("00000-000");
    $(".phone").mask("0000-0000");
    $(".phone_with_ddd").mask("(00) 00000-0000");
    $(".phone_us").mask("(000) 000-0000");
    $(".mixed").mask("AAA 000-S0S");
    $(".cpf").mask("000.000.000-00", {
        reverse: true
    });
    $(".cnpj").mask("00.000.000/0000-00", {
        reverse: true
    });
    $(".money").mask("000.000.000.000.000,00", {
        reverse: true
    });
    $(".money2").mask("#.##0,00", {
        reverse: true
    });
    $(".money3").maskMoney({
        prefix: "R$ ",
        thousands: ".",
        decimal: ",",
        affixesStay: true,
    });
    $(".ip_address").mask("0ZZ.0ZZ.0ZZ.0ZZ", {
        translation: {
            Z: {
                pattern: /[0-9]/,
                optional: true,
            },
        },
    });
    $(".ip_address").mask("099.099.099.099");
    $(".percent").mask("##0,00%", {
        reverse: true
    });
    $(".clear-if-not-match").mask("00/00/0000", {
        clearIfNotMatch: true
    });
    $(".placeholder").mask("00/00/0000", {
        placeholder: "__/__/____"
    });
    $(".fallback").mask("00r00r0000", {
        translation: {
            r: {
                pattern: /[\/]/,
                fallback: "/",
            },
            placeholder: "__/__/____",
        },
    });
    $(".selectonfocus").mask("00/00/0000", {
        selectOnFocus: true
    });
});

function AtualizarEstadoCivil() {
    var elemento = document.getElementById("EstadoCivilInput");

    if (elemento.value == "Solteiro") {
        document.getElementById("dtCasamento").hidden = true;
        document.getElementById("nomeConjuge").hidden = true;
        document.getElementById("dtNascConjuge").hidden = true;
    } else {
        document.getElementById("dtCasamento").hidden = false;
        document.getElementById("nomeConjuge").hidden = false;
        document.getElementById("dtNascConjuge").hidden = false;
    }
}

function AtualizarEstadoCivilCinza() {
    var elemento = document.getElementById("EstadoCivilInput");

    if (elemento.value == "Solteiro") {
        document.getElementById("DataCasamento").hidden = true;
        document.getElementById("NomeConjuge").hidden = true;
        document.getElementById("DataNascConjuge").hidden = true;
    } else {
        document.getElementById("DataCasamento").hidden = false;
        document.getElementById("NomeConjuge").hidden = false;
        document.getElementById("DataNascConjuge").hidden = false;
    }
}