function confirmBorrar(id, seHizoClick) {
    var _confirmBorrar = 'BorrarSpan_' + id;
    var _confirmBorrarSpan = 'confirmBorrarSpan_' + id;

    if (seHizoClick) {
        $('#' + _confirmBorrar).hide();
        $('#' + _confirmBorrarSpan).show();
    }
    else {
        $('#' + _confirmBorrar).show();
        $('#' + _confirmBorrarSpan).hide();
    }
}