$(function() {
    $('#StorageType').change(function() {
        if ($(this).val() == 'MaterialCMS.Services.AzureFileSystem') {
            $('#azure-settings').show();
        } else {
            $('#azure-settings').hide();
        }
    });
    $('#StorageType').change();
})