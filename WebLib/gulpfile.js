/// <binding Clean='clean' />
"use strict";

var gulp = require("gulp"),
    rimraf = require("rimraf"),
    less = require("gulp-sass"); 

var paths = {
    webroot: "./wwwroot/"
};
gulp.task("sass", function () {
    return gulp.src('sass/main.sass')
        .pipe(less())
        .pipe(gulp.dest(paths.webroot + '/css'))
});