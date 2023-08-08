// Include gulp
const { src, dest, watch, series, parallel } = require('gulp');

// Include plugins
const concat = require('gulp-concat');
const rename = require("gulp-rename");
const uglifyEs = require("uglify-es");
const composer = require("gulp-uglify/composer");
const uglify = composer(uglifyEs, console);
const sass = require('gulp-sass');
const clean = require("gulp-clean");


var paths = {
    scss: 'wwwroot/scss/',
    css: 'wwwroot/css/',
};

function jsCleanTask() {
    return src("wwwroot/js/site.min.js", { read: false, allowEmpty: true })
        .pipe(clean());
}

function cleanImagesTask() {
    return src([
        "wwwroot/images/*.png", "!wwwroot/images/drop-down-icon.png", "!wwwroot/images/coming-soon.png",
        "!wwwroot/images/donate-long-pink.png",
        "!wwwroot/images/donate-long-teal.png", "!wwwroot/images/donate-short-pink.png",
        "!wwwroot/images/donate-short-teal.png"
    ],
        { read: false, allowEmpty: true })
        .pipe(clean());
}

function jsTask() {
    return src([
        "wwwroot/js/pages/analytics.js", "node_modules/jquery/dist/jquery.js",
        "node_modules/popper.js/dist/umd/popper.js", "node_modules/jquery-validation/dist/jquery.validate.js",
        "node_modules/jquery-validation-unobtrusive/dist/jquery.validate.unobtrusive.js",
        "node_modules/bootstrap/dist/js/bootstrap.js", "node_modules/bootstrap4-toggle/js/bootstrap4-toggle.min.js",
        "node_modules/sweetalert2/dist/sweetalert2.min.js", "node_modules/promise-polyfill/promise.js",
        "node_modules/datatables/media/js/jquery.dataTables.min.js", "node_modules/driver.js/dist/driver.min.js",
        "node_modules/moment/min/moment.min.js",
        "node_modules/toastr/toastr.js",
        "wwwroot/js/pages/shared/enums.js",
        "node_modules/select2/dist/js/select2.min.js",
        "wwwroot/js/pages/shared/main.js"
    ])
        .pipe(concat("site.js"))
        .pipe(rename({ suffix: ".min" }))
        .pipe(uglify())
        .pipe(dest("wwwroot/js"));
}

function scssTask() {
    return src(paths.scss + '**/*.scss', ['!_variables.scss', '!_common.scss'])
        .pipe(sass({ outputStyle: "compressed" }).on("error", sass.logError))
        .pipe(rename({ suffix: ".min" }))
        .pipe(dest(paths.css));
}

function watchTask() {
    watch([paths.scss + '**/*.scss'],
        parallel(scssTask, userScssTask, jsTask));
}

function migrateImages() {
    return src("node_modules/datatables/media/images/*.png")
        .pipe(dest("wwwroot/images"));
}

// Default Task
exports.default = series(jsCleanTask, cleanImagesTask, parallel(scssTask, jsTask, migrateImages));
exports.watch = series(watchTask);