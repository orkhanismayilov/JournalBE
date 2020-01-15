$(document).ready(function () {

    'use strict';

    let imageSelectItem = $('.images-grid .grid-item'),
        selectedImage = null;

    let titleImgId = $('[name="title_img_id"]').val();
    if(titleImgId){
        selectedImage = imageSelectItem.filter(function(){
            let that = $(this);

            if(that.data('id') == titleImgId){
                return true;
            }
        });
        selectedImage.addClass('active');
    }

    imageSelectItem.click(function () {
        selectedImage = $(this);

        selectedImage.siblings().removeClass('active');
        selectedImage.addClass('active');
    });

    let selectButton = $('#select-title-img');
    selectButton.click(function () {
        if (selectedImage) {
            $('[name="title_img_id"]').val(selectedImage.data('id'));

            let src = selectedImage.find('img').attr('src');
            $('#title-image').attr('src', src);
            $('.title-image-wrapper').slideDown();
        }
    });

    let dismissTitleImageButton = $('.dismiss-title-image');
    dismissTitleImageButton.click(function () {
        selectedImage.removeClass('active');
        selectedImage = null;

        $('[name="title_img_id"]').val('');

        $('.title-image-wrapper').removeClass('d-block').slideUp();
        $('#title-image').removeAttr('arc');
    });

    Dropzone.autoDiscover = false;

    let dropzone = new Dropzone('.dropzone-wrapper', {
        url: '/admin/media/upload/',
        paramName: 'file',
        acceptedFiles: '.jpeg,.jpg,.png',
        parallelUploads: 1,
        timeout: 100000
    });

    let dropzoneNote = $('.dropzone-note');

    dropzone.on('addedfile', function () {
        dropzoneNote.hide();
    });

    dropzone.on('complete', function (file) {
        dropzone.removeFile(file);
    });

    let imagesGrid = $('.images-grid'),
        actualImageId;

    dropzone.on('success', function(file, response) {
        let imageItemTemplate = $('.grid-item.example').clone();

        if(actualImageId != response.id){
            actualImageId = response.id;

            imageItemTemplate.removeClass('example');
            imageItemTemplate.attr('data-id', response.id);
            imageItemTemplate.find('img').attr('src', response.file_dir + 'thumbnails/' + response.filename);
            
            imagesGrid.prepend(imageItemTemplate);

            imageItemTemplate.click(function () {
                selectedImage = $(this);
        
                selectedImage.siblings().removeClass('active');
                selectedImage.addClass('active');
            });
        }

        imageItemTemplate = null;
    });

    dropzone.on('queuecomplete', function(){
        dropzoneNote.fadeIn();
    });    
});