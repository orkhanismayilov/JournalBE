$(document).ready(function () {

    'use strict';

    Dropzone.autoDiscover = false;

    let dropzone = new Dropzone('.dropzone-wrapper', {
        url: '/admin/media/upload/',
        paramName: 'file',
        acceptedFiles: '.jpeg,.jpg,.png'
    });
});