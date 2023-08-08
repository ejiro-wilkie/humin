const Plugins = [
    // jQuery
    {
        from: 'node_modules/jquery/dist',
        to: 'wwwroot/plugins/jquery'
    },
    // Popper
    {
        from: 'node_modules/popper.js/dist',
        to: 'wwwroot/plugins/popper'
    },
    // Bootstrap
    {
        from: 'node_modules/bootstrap/dist/js',
        to: 'wwwroot/plugins/bootstrap/js'
    },
    // Font Awesome
    {
        from: 'node_modules/@fortawesome/fontawesome-free/css',
        to: 'wwwroot/plugins/fontawesome-free/css'
    },
    {
        from: 'node_modules/@fortawesome/fontawesome-free/webfonts',
        to: 'wwwroot/plugins/fontawesome-free/webfonts'
    },
    // overlayScrollbars
    {
        from: 'node_modules/overlayscrollbars/js',
        to: 'wwwroot/plugins/overlayScrollbars/js'
    },
    {
        from: 'node_modules/overlayscrollbars/css',
        to: 'wwwroot/plugins/overlayScrollbars/css'
    },
    // Chart.js
    {
        from: 'node_modules/chart.js/dist/',
        to: 'wwwroot/plugins/chart.js'
    },
    // jQuery UI
    {
        from: 'node_modules/jquery-ui-dist/',
        to: 'wwwroot/plugins/jquery-ui'
    },
    // Flot
    {
        from: 'node_modules/flot/dist/es5/',
        to: 'wwwroot/plugins/flot'
    },
    // Summernote
    {
        from: 'node_modules/summernote/dist/',
        to: 'wwwroot/plugins/summernote'
    },
    // Bootstrap Slider
    {
        from: 'node_modules/bootstrap-slider/dist/',
        to: 'wwwroot/plugins/bootstrap-slider'
    },
    {
        from: 'node_modules/bootstrap-slider/dist/css',
        to: 'wwwroot/plugins/bootstrap-slider/css'
    },
    // Bootstrap Colorpicker
    {
        from: 'node_modules/bootstrap-colorpicker/dist/js',
        to: 'wwwroot/plugins/bootstrap-colorpicker/js'
    },
    {
        from: 'node_modules/bootstrap-colorpicker/dist/css',
        to: 'wwwroot/plugins/bootstrap-colorpicker/css'
    },
    // Tempusdominus Bootstrap 4
    {
        from: 'node_modules/tempusdominus-bootstrap-4/build/js',
        to: 'wwwroot/plugins/tempusdominus-bootstrap-4/js'
    },
    {
        from: 'node_modules/tempusdominus-bootstrap-4/build/css',
        to: 'wwwroot/plugins/tempusdominus-bootstrap-4/css'
    },
    // Moment
    {
        from: 'node_modules/moment/min',
        to: 'wwwroot/plugins/moment'
    },
    {
        from: 'node_modules/moment/locale',
        to: 'wwwroot/plugins/moment/locale'
    },
    // FastClick
    {
        from: 'node_modules/fastclick/lib',
        to: 'wwwroot/plugins/fastclick'
    },
    // Date Range Picker
    {
        from: 'node_modules/daterangepicker/',
        to: 'wwwroot/plugins/daterangepicker'
    },
    // DataTables
    {
        from: 'node_modules/pdfmake/build',
        to: 'wwwroot/plugins/pdfmake'
    },
    {
        from: 'node_modules/jszip/dist',
        to: 'wwwroot/plugins/jszip'
    },
    {
        from: 'node_modules/datatables.net/js',
        to: 'wwwroot/plugins/datatables'
    },
    {
        from: 'node_modules/datatables.net-bs4/js',
        to: 'wwwroot/plugins/datatables-bs4/js'
    },
    {
        from: 'node_modules/datatables.net-bs4/css',
        to: 'wwwroot/plugins/datatables-bs4/css'
    },
    {
        from: 'node_modules/datatables.net-autofill/js',
        to: 'wwwroot/plugins/datatables-autofill/js'
    },
    {
        from: 'node_modules/datatables.net-autofill-bs4/js',
        to: 'wwwroot/plugins/datatables-autofill/js'
    },
    {
        from: 'node_modules/datatables.net-autofill-bs4/css',
        to: 'wwwroot/plugins/datatables-autofill/css'
    },
    {
        from: 'node_modules/datatables.net-buttons/js',
        to: 'wwwroot/plugins/datatables-buttons/js'
    },
    {
        from: 'node_modules/datatables.net-buttons-bs4/js',
        to: 'wwwroot/plugins/datatables-buttons/js'
    },
    {
        from: 'node_modules/datatables.net-buttons-bs4/css',
        to: 'wwwroot/plugins/datatables-buttons/css'
    },
    {
        from: 'node_modules/datatables.net-colreorder/js',
        to: 'wwwroot/plugins/datatables-colreorder/js'
    },
    {
        from: 'node_modules/datatables.net-colreorder-bs4/js',
        to: 'wwwroot/plugins/datatables-colreorder/js'
    },
    {
        from: 'node_modules/datatables.net-colreorder-bs4/css',
        to: 'wwwroot/plugins/datatables-colreorder/css'
    },
    {
        from: 'node_modules/datatables.net-fixedcolumns/js',
        to: 'wwwroot/plugins/datatables-fixedcolumns/js'
    },
    {
        from: 'node_modules/datatables.net-fixedcolumns-bs4/js',
        to: 'wwwroot/plugins/datatables-fixedcolumns/js'
    },
    {
        from: 'node_modules/datatables.net-fixedcolumns-bs4/css',
        to: 'wwwroot/plugins/datatables-fixedcolumns/css'
    },
    {
        from: 'node_modules/datatables.net-fixedheader/js',
        to: 'wwwroot/plugins/datatables-fixedheader/js'
    },
    {
        from: 'node_modules/datatables.net-fixedheader-bs4/js',
        to: 'wwwroot/plugins/datatables-fixedheader/js'
    },
    {
        from: 'node_modules/datatables.net-fixedheader-bs4/css',
        to: 'wwwroot/plugins/datatables-fixedheader/css'
    },
    {
        from: 'node_modules/datatables.net-keytable/js',
        to: 'wwwroot/plugins/datatables-keytable/js'
    },
    {
        from: 'node_modules/datatables.net-keytable-bs4/js',
        to: 'wwwroot/plugins/datatables-keytable/js'
    },
    {
        from: 'node_modules/datatables.net-keytable-bs4/css',
        to: 'wwwroot/plugins/datatables-keytable/css'
    },
    {
        from: 'node_modules/datatables.net-responsive/js',
        to: 'wwwroot/plugins/datatables-responsive/js'
    },
    {
        from: 'node_modules/datatables.net-responsive-bs4/js',
        to: 'wwwroot/plugins/datatables-responsive/js'
    },
    {
        from: 'node_modules/datatables.net-responsive-bs4/css',
        to: 'wwwroot/plugins/datatables-responsive/css'
    },
    {
        from: 'node_modules/datatables.net-rowgroup/js',
        to: 'wwwroot/plugins/datatables-rowgroup/js'
    },
    {
        from: 'node_modules/datatables.net-rowgroup-bs4/js',
        to: 'wwwroot/plugins/datatables-rowgroup/js'
    },
    {
        from: 'node_modules/datatables.net-rowgroup-bs4/css',
        to: 'wwwroot/plugins/datatables-rowgroup/css'
    },
    {
        from: 'node_modules/datatables.net-rowreorder/js',
        to: 'wwwroot/plugins/datatables-rowreorder/js'
    },
    {
        from: 'node_modules/datatables.net-rowreorder-bs4/js',
        to: 'wwwroot/plugins/datatables-rowreorder/js'
    },
    {
        from: 'node_modules/datatables.net-rowreorder-bs4/css',
        to: 'wwwroot/plugins/datatables-rowreorder/css'
    },
    {
        from: 'node_modules/datatables.net-scroller/js',
        to: 'wwwroot/plugins/datatables-scroller/js'
    },
    {
        from: 'node_modules/datatables.net-scroller-bs4/js',
        to: 'wwwroot/plugins/datatables-scroller/js'
    },
    {
        from: 'node_modules/datatables.net-scroller-bs4/css',
        to: 'wwwroot/plugins/datatables-scroller/css'
    },
    {
        from: 'node_modules/datatables.net-select/js',
        to: 'wwwroot/plugins/datatables-select/js'
    },
    {
        from: 'node_modules/datatables.net-select-bs4/js',
        to: 'wwwroot/plugins/datatables-select/js'
    },
    {
        from: 'node_modules/datatables.net-select-bs4/css',
        to: 'wwwroot/plugins/datatables-select/css'
    },

    // Fullcalendar
    {
        from: 'node_modules/@fullcalendar/core/',
        to: 'wwwroot/plugins/fullcalendar'
    },
    {
        from: 'node_modules/@fullcalendar/bootstrap/',
        to: 'wwwroot/plugins/fullcalendar-bootstrap'
    },
    {
        from: 'node_modules/@fullcalendar/daygrid/',
        to: 'wwwroot/plugins/fullcalendar-daygrid'
    },
    {
        from: 'node_modules/@fullcalendar/timegrid/',
        to: 'wwwroot/plugins/fullcalendar-timegrid'
    },
    {
        from: 'node_modules/@fullcalendar/interaction/',
        to: 'wwwroot/plugins/fullcalendar-interaction'
    },
    // icheck bootstrap
    {
        from: 'node_modules/icheck-bootstrap/',
        to: 'wwwroot/plugins/icheck-bootstrap'
    },
    // inputmask
    {
        from: 'node_modules/inputmask/dist/',
        to: 'wwwroot/plugins/inputmask'
    },
    // ion-rangeslider
    {
        from: 'node_modules/ion-rangeslider/',
        to: 'wwwroot/plugins/ion-rangeslider'
    },
    // JQVMap (jqvmap-novulnerability)
    {
        from: 'node_modules/jqvmap-novulnerability/dist/',
        to: 'wwwroot/plugins/jqvmap'
    },
    // jQuery Mapael
    {
        from: 'node_modules/jquery-mapael/js/',
        to: 'wwwroot/plugins/jquery-mapael'
    },
    // Raphael
    {
        from: 'node_modules/raphael/',
        to: 'wwwroot/plugins/raphael'
    },
    // jQuery Mousewheel
    {
        from: 'node_modules/jquery-mousewheel/',
        to: 'wwwroot/plugins/jquery-mousewheel'
    },
    // jQuery Knob
    {
        from: 'node_modules/jquery-knob-chif/dist/',
        to: 'wwwroot/plugins/jquery-knob'
    },
    // pace-progress
    {
        from: 'node_modules/@lgaitan/pace-progress/dist/',
        to: 'wwwroot/plugins/pace-progress'
    },
    // Select2
    {
        from: 'node_modules/select2/dist/',
        to: 'wwwroot/plugins/select2'
    },
    {
        from: 'node_modules/@ttskch/select2-bootstrap4-theme/dist/',
        to: 'wwwroot/plugins/select2-bootstrap4-theme'
    },
    // Sparklines
    {
        from: 'node_modules/sparklines/source/',
        to: 'wwwroot/plugins/sparklines'
    },
    // SweetAlert2
    {
        from: 'node_modules/sweetalert2/dist/',
        to: 'wwwroot/plugins/sweetalert2'
    },
    {
        from: 'node_modules/@sweetalert2/theme-bootstrap-4/',
        to: 'wwwroot/plugins/sweetalert2-theme-bootstrap-4'
    },
    // Toastr
    {
        from: 'node_modules/toastr/build/',
        to: 'wwwroot/plugins/toastr'
    },
    // jsGrid
    {
        from: 'node_modules/jsgrid/dist',
        to: 'wwwroot/plugins/jsgrid'
    },
    {
        from: 'node_modules/jsgrid/demos/',
        to: 'wwwroot/plugins/jsgrid/demos'
    },
    // flag-icon-css
    {
        from: 'node_modules/flag-icon-css/css',
        to: 'wwwroot/plugins/flag-icon-css/css'
    },
    {
        from: 'node_modules/flag-icon-css/flags',
        to: 'wwwroot/plugins/flag-icon-css/flags'
    },
    // bootstrap4-duallistbox
    {
        from: 'node_modules/bootstrap4-duallistbox/dist',
        to: 'wwwroot/plugins/bootstrap4-duallistbox/'
    },
    // filterizr
    {
        from: 'node_modules/filterizr/dist',
        to: 'wwwroot/plugins/filterizr/'
    },
    // ekko-lightbox
    {
        from: 'node_modules/ekko-lightbox/dist',
        to: 'wwwroot/plugins/ekko-lightbox/'
    },
    // bootstrap-switch
    {
        from: 'node_modules/bootstrap-switch/dist',
        to: 'wwwroot/plugins/bootstrap-switch/'
    },
    // jQuery Validate
    {
        from: 'node_modules/jquery-validation/dist/',
        to: 'wwwroot/plugins/jquery-validation'
    },
    // bs-custom-file-input
    {
        from: 'node_modules/bs-custom-file-input/dist/',
        to: 'wwwroot/plugins/bs-custom-file-input'
    },
];

module.exports = Plugins;
