'use strict';

let editorAZ = document.querySelector('#editor-az');
let editorEN = document.querySelector('#editor-en');

if (editorAZ) {
    ClassicEditor
        .create(editorAZ, {
            toolbar: {
                items: [
                    'CKFinder',
                    'heading',
                    '|',
                    'undo',
                    'redo',
                    '|',
                    'bold',
                    'italic',
                    'underline',
                    'strikethrough',
                    'removeFormat',
                    'superscript',
                    'subscript',
                    '|',
                    'alignment',
                    'indent',
                    'outdent',
                    'bulletedList',
                    'numberedList',
                    'horizontalLine',
                    '|',
                    'link',
                    'blockQuote',
                    '|',
                    // 'imageUpload',
                    'insertTable',
                    'mediaEmbed',
                    'fileBrowse'
                ]
            },
            language: 'en',
            image: {
                toolbar: [
                    'imageTextAlternative',
                    'imageStyle:full',
                    'imageStyle:side'
                ]
            },
            table: {
                contentToolbar: [
                    'tableColumn',
                    'tableRow',
                    'mergeTableCells'
                ]
            }
        })
        .then(editor => console.log(editor))
        .catch(error => console.log(error));
}