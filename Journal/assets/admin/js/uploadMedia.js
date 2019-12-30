$(document).ready(function () {

    'use strict';

    Dropzone.autoDiscover = false;

    let dropzone = new Dropzone('.dropzone-wrapper', {
        url: '/admin/media/upload/',
        paramName: 'file',
        acceptedFiles: '.jpeg,.jpg,.png'
    });

    let dropzoneNote = $('.dropzone-note');

    dropzone.on('addedfile', function () {
        dropzoneNote.hide();
    });

    dropzone.on('queuecomplete', function(){
        dropzoneNote.fadeIn();
    });

    dropzone.on('complete', function (file) {
        dropzone.removeFile(file);
    });
});