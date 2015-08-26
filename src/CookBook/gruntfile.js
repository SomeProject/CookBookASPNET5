/*
This file in the main entry point for defining grunt tasks and using grunt plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkID=513275&clcid=0x409
*/
module.exports = function (grunt) {
    // load Grunt plugins from NPM
    grunt.loadNpmTasks("grunt-contrib-uglify");
    grunt.loadNpmTasks("grunt-contrib-watch");
    grunt.loadNpmTasks("grunt-bower-task");

    // configure plugins
    grunt.initConfig({
        uglify: {
            my_target: {
                files: { "wwwroot/app.js": ["Scripts/app.js", "Scripts/**/*.js"] }
            }
        },

        watch: {
            scripts: {
                files: ["Scripts/**/*.js"],
                tasks: ["uglify"]
            }
        },
        
        bower: {
            install: {
                options: {
                    targetDir: "wwwroot/lib",
                    layout: "byComponent",
                    cleanTargetDir: true
                }
            }
        }
    });

    // define tasks
    grunt.registerTask("default", ["bower", "uglify", "watch"]);
};