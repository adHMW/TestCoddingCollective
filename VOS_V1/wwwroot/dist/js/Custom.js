$(function () {
    var placeholderElement = $('#modal-placeholder');
    $('button[data-toggle="ajax-modal"]').click(function (event) {
        var url = $(this).data('url');
        $.get(url).done(function (data) {
            placeholderElement.html(data);
            placeholderElement.find('.modal').modal('show');
            $('.select2').select2();
            placeholderElement.on('click', '[data-save="modal"]', function (event) {
                event.preventDefault();
                var form = $(this).parents('.modal').find('form');
                var actionUrl = form.attr('action');
                var dataToSend = form.serialize();

                $.post(actionUrl, dataToSend).done(function (data) {
                    var newBody = $('.modal-body', data);
                    placeholderElement.find('.modal-body').replaceWith(newBody);

                    $('.select2').select2();
                    var isValid = newBody.find('[name="IsValid"]').val() == 'True';
                    if (isValid) {
                        placeholderElement.find('.modal').modal('hide');
                        location.reload(true);
                    }
                });
            });
        });
    });
});

$(function () {
    var placeholderElement = $('#modal-placeholder');
    $('a[data-toggle="ajax-modal"]').click(function (event) {
        event.preventDefault();
        var url = $(this).attr('href');
        $.get(url).done(function (data) {
            placeholderElement.html(data);
            placeholderElement.find('.modal').modal('show');
            $('.select2').select2();
            placeholderElement.on('click', '[data-save="modal"]', function (event) {
                event.preventDefault();
                var form = $(this).parents('.modal').find('form');
                var actionUrl = form.attr('action');
                var dataToSend = form.serialize();

                $.post(actionUrl, dataToSend).done(function (data) {
                    var newBody = $('.modal-body', data);
                    placeholderElement.find('.modal-body').replaceWith(newBody);

                    $('.select2').select2();
                    var isValid = newBody.find('[name="IsValid"]').val() == 'True';
                    if (isValid) {
                        placeholderElement.find('.modal').modal('hide');
                        location.reload(true);
                    }
                });
            });
        });
    });
});

//$(function () {
//    $('.ajax-text').blur(function (event) {
//        var placeholderTag = '.' + $(this).attr('id');
//        var placeholderElement = $(placeholderTag);
//        var paramVal = $(this).val();
//        $.get('/Home/Validate?userID=' + paramVal).done(function (data) {
//            placeholderElement.val(data);
//        });
//    });
//});

$(function () {
    $('input[name="periodRange"]').daterangepicker({
        locale: {
            format: 'YYYY/MM'
        }
    });
});

$(function () {
    $('input[name="period"]').datepicker({
        format: "yyyy/mm",
        viewMode: "months",
        minViewMode: "months"
    });
});

$(function () {
    $('.select2').select2();
});

$(function () {
    var placeholderElement = $('#warning-placeholder');
    var modalPlaceholder = $('#modal-upload');
    $('button[data-save="unclaimed-check"]').click(function (event) {
        event.preventDefault();
        var form = $(this).parents('.modal').find('form');

        var fileUpload = $("#csvFile").get(0);
        var files = fileUpload.files;

        var actionUrl = form.attr('action');
        var dataToSend = new FormData()//form.serialize();
        dataToSend.append('nblfile', files[0]);

        if (files[0] == null) {
            alert("Please select file before upload!");
            return;
        }

        $.ajax({
            type: "POST",
            url: actionUrl,
            contentType: false,
            processData: false,
            data: dataToSend,
            success: function (message) {
                placeholderElement.html(message);
                var isValid = $(placeholderElement).find('[name="IsValid"]').val() == 'true';
                if (isValid) {
                    location.reload(true);
                }
            },
            error: function () {
                alert("There was error uploading files!");
            }
        });
    });
});



$(document).on({
    ajaxStart: function () { $("body").addClass("loading"); },
    ajaxComplete: function () { $("body").removeClass("loading"); }
});


$(function () {
    $('.ajax-text').on('input blur', function (event) {
        var placeholderTag = '.' + $(this).attr('id');
        var placeholderElement = $(placeholderTag);
        var paramVal = $(this).val();
        if (paramVal.length == 10) {
            $.get('/Claim/Validate?userID=' + paramVal).done(function (data) {
                if (data.name != "") {
                    placeholderElement.val(data.name);
                    placeholderElement.eq(1).val(data.branchID);
                    placeholderElement.eq(2).val(data.salesLevelDesc);
                    placeholderElement.parent().parent().find('input[type="checkbox"]').prop('disabled', false);
                } else {
                    placeholderElement.val(data.name);
                    placeholderElement.eq(1).val(data.branchID);
                    placeholderElement.eq(2).val(data.salesLevelDesc);
                    placeholderElement.parent().parent().find('input[type="checkbox"]').prop('disabled', true);
                }
            });
        }
    });
});



$(function () {
    $('button[data-save="sales"]').click(function (event) {
        event.preventDefault();
        var form = $(this).parents('.modal').find('form');

        var fileUpload = $("#csvFile").get(0);
        var files = fileUpload.files;

        var actionUrl = form.attr('action');
        var dataToSend = new FormData()//form.serialize();
        dataToSend.append('salesfile', files[0]);

        if (files[0] == null) {
            alert("Please select file before upload!");
            return;
        }

        $.ajax({
            type: "POST",
            url: actionUrl,
            contentType: false,
            processData: false,
            data: dataToSend,
            success: function (message) {
                location.reload(true);
            },
            error: function () {
                alert("There was error uploading files!");
            }
        });
    });
});

/*
$(function () {
    $("[type='checkbox']").change(function () {
        if (this.checked) {
            var className = "." + this.className;
            $(className).not(this).prop('disabled', true);
            $(this).parent().parent().find('input').eq(1).prop('disabled', false);
        } else if (!this.checked) {
            var className = "." + this.className;
            $(className).prop('disabled', false);
            $('input[type="checkbox"]' + className).prop('disabled', true);
            $('.ajax-text').trigger('input');
        }
    });
});*/


$(function () {
    $('button[data-save="submitClaim"]').click(function (event) {
        if ($("input:checkbox:checked").length == 0) {
            alert("Please select one or more data before submit!");
            return;
        } else {
            this.submit();
        }
    });
});


$(function () {
    $(".checkbox-toggle").click(function () {
        var clicks = $(this).data('clicks');
        if (clicks) {
            //Uncheck all checkboxes
            $(".table input[type='checkbox']").iCheck("uncheck");
            $(".fa", this).removeClass("fa-check-square-o").addClass('fa-square-o');
        } else {
            //Check all checkboxes
            $(".table input[type='checkbox']").iCheck("check");
            $(".fa", this).removeClass("fa-square-o").addClass('fa-check-square-o');
        }
        $(this).data("clicks", !clicks);
    });
});
/*
$(function ($) {

    $(".sidebar-dropdown > a").click(function () {
        $(".sidebar-submenu").slideUp(200);
        if (
            $(this)
                .parent()
                .hasClass("active")
        ) {
            $(".sidebar-dropdown").removeClass("active");
            $(this)
                .parent()
                .removeClass("active");
        } else {
            $(".sidebar-dropdown").removeClass("active");
            $(this)
                .next(".sidebar-submenu")
                .slideDown(200);
            $(this)
                .parent()
                .addClass("active");
        }
    });

    $("#close-sidebar").click(function () {
        $(".page-wrapper").removeClass("toggled");
    });
    $("#show-sidebar").click(function () {
        $(".page-wrapper").addClass("toggled");
    });




});
*/


function selectTransTypeFMTR(element) {
   
    var divFMTR = document.getElementById("FMTRTable");
    switch (element.options[element.selectedIndex].text) {
        case "Jenis Transaksi Lainnya":
           
            break;
        case "Faktur Pajak dengan KL PPN Tertunda":
           
            divFMTR.style.display = "none";
            break;
        case "Faktur Pajak dengan KL PPN Cabang":
            divFMTR.style.display = "block";
            break;
        case "Faktur Pajak tanpa KL PPN":
           
            divFMTR.style.display = "none";
            break;
        case "Select":
            
            break;
        default:
        // code block
    }

}

function selectTransType(element) {
    var divUplMemo = document.getElementById("divUplMemo");
    var divUplInvoice = document.getElementById("divUplInvoice");
    var divUplWapu = document.getElementById("divUplWapu");
    var divUplVoucher = document.getElementById("divUplVoucher");
    var divFMTR = document.getElementById("FMTRTable");
    switch (element.options[element.selectedIndex].text) {
        case "Jenis Transaksi Lainnya":
            divUplMemo.style.display = "flex";
            divUplInvoice.style.display = "flex";
            divUplWapu.style.display = "flex";
            divUplVoucher.style.display = "flex";
            break;
        case "Faktur Pajak dengan KL PPN Tertunda":
            divUplMemo.style.display = "flex";
            divUplInvoice.style.display = "flex";
            divUplWapu.style.display = "none";
            divUplVoucher.style.display = "flex";
            divFMTR.style.display = "none";
            break;
        case "Faktur Pajak dengan KL PPN Cabang":
            divUplMemo.style.display = "flex";
            divUplInvoice.style.display = "flex";
            divUplWapu.style.display = "none";
            divUplVoucher.style.display = "flex";
            break;
        case "Faktur Pajak tanpa KL PPN":
            divUplMemo.style.display = "flex";
            divUplInvoice.style.display = "flex";
            divUplWapu.style.display = "none";
            divUplVoucher.style.display = "flex";
            divFMTR.style.display = "none";
            break;
        case "Select":
            divUplMemo.style.display = "none";
            divUplInvoice.style.display = "none";
            divUplWapu.style.display = "none";
            divUplVoucher.style.display = "none";
            break;
        default:
        // code block
    }

}


// Jquery Dependency

$("input[data-type='currency']").on({
    keyup: function () {
        formatCurrency($(this));
    },
    blur: function () {
        formatCurrency($(this), "blur");
    }
});





function formatCurrency(input, blur) {
    // appends $ to value, validates decimal side
    // and puts cursor back in right position.

    // get input value
    var input_val = input.val();

    // don't validate empty input
    if (input_val === "") { return; }

    // original length
    var original_len = input_val.length;

    // initial caret position 
    var caret_pos = input.prop("selectionStart");

    // check for decimal
    if (input_val.indexOf(".") >= 0) {

        // get position of first decimal
        // this prevents multiple decimals from
        // being entered
        var decimal_pos = input_val.indexOf(".");

        // split number by decimal point
        var left_side = input_val.substring(0, decimal_pos);
        var right_side = input_val.substring(decimal_pos);

        // add commas to left side of number
        left_side = formatNumber(left_side);

        // validate right side
        right_side = formatNumber(right_side);

        // On blur make sure 2 numbers after decimal
        if (blur === "blur") {
            right_side += "00";
        }

        // Limit decimal to only 2 digits
        right_side = right_side.substring(0, 2);

        // join number by .
        input_val =  left_side + "." + right_side;

    } else {
        // no decimal entered
        // add commas to number
        // remove all non-digits
        input_val = formatNumber(input_val);
        input_val = input_val;

        // final formatting
        if (blur === "blur") {
            input_val += ".00";
        }
    }

    // send updated string to input
    input.val(input_val);

    // put caret back in the right position
    var updated_len = input_val.length;
    caret_pos = updated_len - original_len + caret_pos;
    input[0].setSelectionRange(caret_pos, caret_pos);
}


function HJChange(_val) {

    var hjdoc = _val.value;
    console.log('masuk');
    //var value = hjdoc * $('#txtKursTax')[0].value;
    var value = hjdoc * document.getElementById('#txtKursTax');
    var value = hjdoc * $('#txtKursTax')[0].value;
    var result = Math.floor(value);
    var resultFinal = numberWithCommas(result);
//Harga Jual
    $('#txtHJ').val(resultFinal);
    
//Harga Jual (in Doc)
    var resulthjdoc = numberWithCommas(hjdoc);
    $('#txtHJDoc').val(resulthjdoc);
    PPNChange();
}

function PPNChange() {
    calculatePPN();
}
function terbilang(a) {
    var c = " Satu Dua Tiga Empat Lima Enam Tujuh Delapan Sembilan Sepuluh Sebelas".split(" "); if (12 > a) var b = c[a]; else 20 > a ? b = c[a - 10] + " Belas" : 100 > a ? (b = parseInt(String(a / 10).substr(0, 1)), b = c[b] + " Puluh " + c[a % 10]) : 200 > a ? b = "Seratus " + terbilang(a - 100) : 1E3 > a ? (b = parseInt(String(a / 100).substr(0, 1)), b = c[b] + " Ratus " + terbilang(a % 100)) : 2E3 > a ? b = "Seribu " + terbilang(a - 1E3) : 1E4 > a ? (b = parseInt(String(a / 1E3).substr(0, 1)), b = c[b] + " Ribu " + terbilang(a % 1E3)) : 1E5 > a ? (b = parseInt(String(a / 100).substr(0, 2)),
        a %= 1E3, b = terbilang(b) + " Ribu " + terbilang(a)) : 1E6 > a ? (b = parseInt(String(a / 1E3).substr(0, 3)), a %= 1E3, b = terbilang(b) + " Ribu " + terbilang(a)) : 1E8 > a ? (b = parseInt(String(a / 1E6).substr(0, 4)), a %= 1E6, b = terbilang(b) + " Juta " + terbilang(a)) : 1E9 > a ? (b = parseInt(String(a / 1E6).substr(0, 4)), a %= 1E6, b = terbilang(b) + " Juta " + terbilang(a)) : 1E10 > a ? (b = parseInt(String(a / 1E9).substr(0, 1)), a %= 1E9, b = terbilang(b) + " Milyar " + terbilang(a)) : 1E11 > a ? (b = parseInt(String(a / 1E9).substr(0, 2)), a %= 1E9, b = terbilang(b) + " Milyar " + terbilang(a)) :
            1E12 > a ? (b = parseInt(String(a / 1E9).substr(0, 3)), a %= 1E9, b = terbilang(b) + " Milyar " + terbilang(a)) : 1E13 > a ? (b = parseInt(String(a / 1E10).substr(0, 1)), a %= 1E10, b = terbilang(b) + " Triliun " + terbilang(a)) : 1E14 > a ? (b = parseInt(String(a / 1E12).substr(0, 2)), a %= 1E12, b = terbilang(b) + " Triliun " + terbilang(a)) : 1E15 > a ? (b = parseInt(String(a / 1E12).substr(0, 3)), a %= 1E12, b = terbilang(b) + " Triliun " + terbilang(a)) : 1E16 > a && (b = parseInt(String(a / 1E15).substr(0, 1)), a %= 1E15, b = terbilang(b) + " Kuadriliun " + terbilang(a)); a = b.split(" "); c = []; for (b = 0; b < a.length; b++)"" != a[b] && c.push(a[b]); return c.join(" ")
};

function PPNSum(InputFakturPajaksendiri) {
    var bilangan = ['', 'Satu', 'Dua', 'Tiga', 'Empat', 'Lima', 'Enam', 'Tujuh', 'Delapan', 'Sembilan', 'Sepuluh', 'Sebelas'];
    var adjustTambah = numberWithDotsRemove(document.getElementById("inputAdjustTambah").value);
    var adjustKurang = numberWithDotsRemove(document.getElementById("inputAdjustKurang").value);
    var adjustKurangKompensasi = numberWithDotsRemove(document.getElementById("inputAdjustKurangKompensasi").value);
    var nilaiKompensasi;
    var bukanWapu = numberWithDotsRemove(document.getElementById("InputFakturPajaksendiri").value);
    var value;

    value = parseInt(bukanWapu) + parseInt(adjustTambah) - parseInt(adjustKurang) - parseInt(adjustKurangKompensasi);

    if (value < 12) {
        var kalimat = bilangan[value];
    }
    // 12 - 19
    else if (value < 20) {
        var kalimat = bilangan[value - 10] + ' Belas';
    }
    // 20 - 99
    else if (value < 100) {
        var utama = value / 10;
        var depan = parseInt(String(utama).substr(0, 1));
        var belakang = value % 10;
        var kalimat = bilangan[depan] + ' Puluh ' + bilangan[belakang];
    }
    // 100 - 199
    else if (value < 200) {
        var kalimat = 'Seratus ' + terbilang(value - 100);
    }
    // 200 - 999
    else if (value < 1000) {
        var utama = value / 100;
        var depan = parseInt(String(utama).substr(0, 1));
        var belakang = value % 100;
        var kalimat = bilangan[depan] + ' Ratus ' + terbilang(belakang);
    }
    // 1,000 - 1,999
    else if (value < 2000) {
        var kalimat = 'Seribu ' + terbilang(value - 1000);
    }
    // 2,000 - 9,999
    else if (value < 10000) {
        var utama = value / 1000;
        var depan = parseInt(String(utama).substr(0, 1));
        var belakang = value % 1000;
        var kalimat = bilangan[depan] + ' Ribu ' + terbilang(belakang);
    }
    // 10,000 - 99,999
    else if (value < 100000) {
        var utama = value / 100;
        var depan = parseInt(String(utama).substr(0, 2));
        var belakang = value % 100;
        var belakang = value % 1000;
        var kalimat = terbilang(depan) + ' Ribu ' + terbilang(belakang);
    }
    // 100,000 - 999,999
    else if (value < 1000000) {
        var utama = value / 1000;
        var depan = parseInt(String(utama).substr(0, 3));
        var belakang = value % 1000;
        var kalimat = terbilang(depan) + ' Ribu ' + terbilang(belakang);
    }
    // 1,000,000 - 	99,999,999
    else if (value < 100000000) {
        var utama = value / 1000000;
        var depan = parseInt(String(utama).substr(0, 4));
        var belakang = value % 1000000;
        var kalimat = terbilang(depan) + ' Juta ' + terbilang(belakang);
    }
    else if (value < 1000000000) {
        var utama = value / 1000000;
        var depan = parseInt(String(utama).substr(0, 4));
        var belakang = value % 1000000;
        var kalimat = terbilang(depan) + ' Juta ' + terbilang(belakang);
    }
    else if (value < 10000000000) {
        var utama = value / 1000000000;
        var depan = parseInt(String(utama).substr(0, 1));
        var belakang = value % 1000000000;
        var kalimat = terbilang(depan) + ' Milyar ' + terbilang(belakang);
    }
    else if (value < 100000000000) {
        var utama = value / 1000000000;
        var depan = parseInt(String(utama).substr(0, 2));
        var belakang = value % 1000000000;
        var kalimat = terbilang(depan) + ' Milyar ' + terbilang(belakang);
    }
    else if (value < 1000000000000) {
        var utama = value / 1000000000;
        var depan = parseInt(String(utama).substr(0, 3));
        var belakang = value % 1000000000;
        var kalimat = terbilang(depan) + ' Milyar ' + terbilang(belakang);
    }
    else if (value < 10000000000000) {
        var utama = value / 10000000000;
        var depan = parseInt(String(utama).substr(0, 1));
        var belakang = value % 10000000000;
        var kalimat = terbilang(depan) + ' Triliun ' + terbilang(belakang);
    }
    else if (value < 100000000000000) {
        var utama = value / 1000000000000;
        var depan = parseInt(String(utama).substr(0, 2));
        var belakang = value % 1000000000000;
        var kalimat = terbilang(depan) + ' Triliun ' + terbilang(belakang);
    }
    else if (value < 1000000000000000) {
        var utama = value / 1000000000000;
        var depan = parseInt(String(utama).substr(0, 3));
        var belakang = value % 1000000000000;
        var kalimat = terbilang(depan) + ' Triliun ' + terbilang(belakang);
    }
    else if (value < 10000000000000000) {
        var utama = value / 1000000000000000;
        var depan = parseInt(String(utama).substr(0, 1));
        var belakang = value % 1000000000000000;
        var kalimat = terbilang(depan) + ' Kuadriliun ' + terbilang(belakang);
    }

    
    
    var result = numberWithDots(value);
    var adjustT = numberWithDots(adjustTambah);
    var adjustK = numberWithDots(adjustKurang);
    var adjustKom = numberWithDots(adjustKurangKompensasi);

    if (parseInt(adjustTambah) > 0 || parseInt(adjustKurang) > 0 || parseInt(adjustKom) > 0) {
        $('#totalBayar_PPN').val(result);
        $('#totalBayar_PPNtable').val(result);
        $('#nominal_PPN').val(result);
    }
    else {
        console.log("test")
        $('#totalBayar_PPN').val(bukanWapu);
        $('#totalBayar_PPNtable').val(bukanWapu);
        $('#nominal_PPN').val(bukanWapu);
    }
    
    $('#TERBILANG').val(kalimat);
    $('#adjustTambahlabel').val(adjustT);
    $('#inputAdjustTambah').val(adjustT);
    $('#adjustKuranglabel').val(adjustK);
    $('#inputAdjustKurang').val(adjustK);
    $('#inputAdjustKurangKompensasi').val(adjustKom);
    $('#inputTerbilang').val(kalimat);
   
}

function calculatePPN() {
  
    var skillsSelect = document.getElementById("TARIFF_PPN");
    var mataUang = document.getElementById("CURRENCY");

    var selectedText = skillsSelect.options[skillsSelect.selectedIndex].text;

    console.log(selectedText);
    var selectedTextmataUang = mataUang.options[mataUang.selectedIndex].text;

    var txtHj = document.getElementById("txtHJ").value;
    var txtHJinDoc = document.getElementById("txtHJDoc").value;
    var txtHjUnformat = numberWithCommasRemove(txtHj);
    var txtHjUnformatinDOC = numberWithCommasRemove(txtHJinDoc);

    if (selectedTextmataUang == "USD") {
        console.log($('#txtKursTax')[0].value);
        console.log(txtHjUnformatinDOC);
        var valueHargaJual = Math.floor(txtHjUnformatinDOC * $('#txtKursTax')[0].value);
        var value = (Math.floor(valueHargaJual * 10) / 100).toFixed(2);
        // var ppnCustodian = txtHjUnformatinDOC * (selectedText / 100);
        // var ppnCustodianConvert = (Math.trunc(ppnCustodian * 100) / 100).toFixed(2);
        // var value = ppnCustodianConvert * $('#txtKursTax')[0].value;
        alert(value);
    }
    else
    {
        var value = txtHjUnformat * (selectedText / 100);
    }
    var converResult = Math.trunc(value);
    $('#txtPPNIdr').val(numberWithCommas(converResult));
}

function preventifTest(ID) {
    $(document).ready(function () {
        $('#btnSubmit').on('click', function (event) {
            event.preventDefault();
            var el = $(this);
            el.prop('disabled', true);
            setTimeout(function () { el.prop('disabled', false); }, 3000);
            alert('Your form has been already submited. wait please');
        });
    });
}




function NumberFormat(_val) {
    var hjdoc = _val.value;
    var result = numberWithCommas(hjdoc);
  
    document.getElementById(_val.id).value = result;
}

function numberWithCommas(x) {
        return x.toString().replace(/\B(?<!\.\d*)(?=(\d{3})+(?!\d))/g, ",");
}

function numberWithDots(x) {
    return x.toString().replace(/\B(?<!\.\d*)(?=(\d{3})+(?!\d))/g, ".");
    
}

function numberWithCommasRemove(x) {

    return x.toString().replace(/,/g, '');
}

function numberWithDotsRemove(x) {

    return x.toString().replace(/\./g, '');
}

function numberWithCommasRemoveChangeDot(x) {
    //alert('asd '+x);
    //var x2 = x.toString().replace(/\./gi, ',');
    //alert(x2);
    return x.toString().replace(/\./gi, ',');
}

function getCurrency(_val) {
    alert("curr "+_val)
    if (_val.value != 'IDR') {
        var data = "";
        var _url = '@Url.Action("GetCurrencyValue", "Transactions")';
        $.ajax({
            type: "GET",
            url: _url,
            data: { _currency: _val.value },
            success: function (response) {
                $('#txtKursTax').val((response));

                //return response;
            },
            error: function () {
                alert('Error occured get currency value');
            }
        });
        
    }
    else {
        $('#txtKursTax').val(1);
    }
}


function npwpFormat() {

    var npwp = document.getElementById("InputNpwp").value;
    console.log(npwp);
    var npwpFormated = formatNpwp(npwp);
    console.log(npwpFormated);
    document.getElementById("InputNpwp").value = npwpFormated;
    $('#InputNpwp').val(npwpFormated);
}

function inputtransactiononubmit() {

    var npwp = document.getElementById("InputNpwp").value;

    var npwpFormated = removeformatNpwp(npwp);
    document.getElementById("InputNpwp").value = npwpFormated;
  

}

function npwpMasterFormat() {
    var npwp = document.getElementById("NPWP").value;
   
    var npwpFormated = formatNpwp(npwp);
    document.getElementById("NPWP").value = npwpFormated;
}

function inputtNPWPMasteronsubmit() {

    var npwp = document.getElementById("NPWP").value;

    var npwpFormated = removeformatNpwp(npwp);
    document.getElementById("NPWP").value = npwpFormated;
}

function formatNpwp(value) {
    return value.replace(/(\d{2})(\d{3})(\d{3})(\d{1})(\d{3})(\d{3})/, "$1.$2.$3.$4-$5.$6");
}

function removeformatNpwp(value) {
    return value.replace(/[^0-9a-zA-Z]/gi, "");
}

function DisplayProgressMessage(ctl, msg, spl) {
    $(ctl).prop("disabled", true);
    $(ctl).text(msg);
    $(spl).removeClass("hidden")
    return true;
}



