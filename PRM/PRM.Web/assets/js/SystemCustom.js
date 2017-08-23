var modalCount = 0;

function ShowModal(src, frameSize, frameHeight, caption, submitObject) {
    var mdl = null;
    var html = '';
    window.top.modalCount++;

    if (window.top.$('#dvNMModal' + window.top.modalCount).length > 0) {
        mdl = window.top.$('#dvNMModal' + window.top.modalCount);
    }
    else {
        mdl = window.top.document.createElement('div');
        mdl.id = 'dvNMModal' + window.top.modalCount;
        mdl.className = 'modal modal-padding-right fade' + (frameSize == 'lg' ? ' bs-example-modal-lg' : (frameSize == 'sm' ? ' bs-example-modal-sm' : (frameSize == 'full' ? ' bs-example-modal-lg' : '')));
        mdl.setAttribute('tabindex', '-1');
        mdl.setAttribute('role', 'dialog');
        mdl.setAttribute('aria-labelledby', 'myModalLabel' + window.top.modalCount);
        mdl.setAttribute('aria-hidden', 'true');
        mdl = window.top.$(mdl);
        mdl.css('z-index', 10000 + (window.top.modalCount * 10))
        mdl.css('overflow', 'hidden');
    }
    html += '<div class="modal-dialog' + (frameSize == 'lg' ? ' modal-lg' : (frameSize == 'sm' ? ' modal-sm' : (frameSize == 'full' ? ' modal-full' : ''))) + ' modal-dialog-margin" style="max-height:' + frameHeight + 'px!important;overflow:visible;z-index:' + 100 + (window.top.modalCount * 10) + '!important;">';
    html += '<div class="modal-content">';
    html += '<div class="modal-header">';
    html += '<button id="btnCloseModal" type="button" class="close" title="Kapat" onclick="CloseModal(true);">x</button>';
    html += '<h4 class="modal-title" id="myModalLabel' + window.top.modalCount + '">' + caption + '</h4>';
    html += '</div>';
    html += '<div class="modal-body" style="padding:0px!important;height:' + frameHeight + 'px!important;">';
    html += '<iframe src="' + src + '" id="NFrame' + window.top.modalCount + '"  name="NFrame' + window.top.modalCount + '"  frameborder="0" style="width:100%;height:100%;" /> ';
    html += '</div>';
    html += '</div>';
    html += '</div>';

    mdl.html(html);
    if (submitObject) {
        mdl.attr('submitObject', submitObject);
    }
    else {
        mdl.attr('submitObject', null);
    }

    var m = mdl.modal({ show: true, backdrop: 'static', keyboard: false });



    mdl.find('.modal-content').draggable({
        handle: ".modal-header"
    });
}
function CloseModal(doSubmit, submitObject) {
    if (window.top.$('#dvNMModal' + window.top.modalCount).length > 0) {
        var modal = window.top.$('#dvNMModal' + window.top.modalCount);
        modal.modal('hide');
        if (doSubmit) {
            if (submitObject) {
                fp(submitObject).click();
            }
            else if (modal.attr('submitObject')) {
                fp(modal.attr('submitObject')).click();
            }
        }
        window.top.modalCount--;
    }
}
function fp(obj) {
    if (window.top.modalCount == 1) { /*1. seviye*/
        return window.top.$('#' + obj);
    }
    else {
        return window.top.$('#NFrame' + (window.top.modalCount - 1)).contents().find('#' + obj)
    }
}
function fo(obj) {
    if (window.top.modalCount == 0) { /*1. seviye*/
        return window.top.$('#' + obj);
    }
    else {
        return window.top.$('#NFrame' + (window.top.modalCount)).contents().find('#' + obj)
    }
}
function htmlEncode(value) {
    return $('<div/>').text(value).html();
}
function htmlDecode(value) {
    return $('<div/>').html(value).text();
}
//if (Sys) {
//    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestPublic);
//    Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestPublic);
//}

//function BeginRequestPublic() {

//}
//function EndRequestPublic() {

//}

function SetUniqueRadioButton(nameregex, current) {
    $("input:radio[name*='" + nameregex + "']").each(
    function () {
        if (this.id != current.id) {
            this.checked = false;
        }
    });
    current.checked = true;
}
$('.OnlyNumeric').keydown(function (e) {
    if (e.which != 8 && e.which != 13) {
        if (!String.fromCharCode(e.which).match(/[0-9]/g)) {
            e.preventDefault();
        }
    }
});