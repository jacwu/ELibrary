// Karma configuration
// Generated on Wed Aug 03 2016 09:00:07 GMT+0800 (China Standard Time)

module.exports = function (config) {
    config.set({

        // base path that will be used to resolve all patterns (eg. files, exclude)
        basePath: '',


        // frameworks to use
        // available frameworks: https://npmjs.org/browse/keyword/karma-adapter
        frameworks: ['jasmine'],


        // list of files / patterns to load in the browser
        files: [
          'Scripts/jquery.js',
          'Scripts/angular.js',
          'node_modules/angular-mocks/angular-mocks.js',
          'node_modules/jasmine-ajax/lib/mock-ajax.js',
          'node_modules/jasmine-jquery/lib/jasmine-jquery.js',
          'Scripts/app/**/*.js',
          'Scripts/app/**/*.html',
          'Specs/app/**/*.js'
        ],


        // list of files to exclude
        exclude: [
        ],


        // preprocess matching files before serving them to the browser
        // available preprocessors: https://npmjs.org/browse/keyword/karma-preprocessor
        preprocessors: {
            'Scripts/app/**/*.js': ['coverage'],
            'Scripts/app/**/*.html': ['ng-html2js']
        },


        // test results reporter to use
        // possible values: 'dots', 'progress'
        // available reporters: https://npmjs.org/browse/keyword/karma-reporter
        reporters: ['progress', 'junit', 'html', 'coverage'],


        // web server port
        port: 9876,


        // enable / disable colors in the output (reporters and logs)
        colors: true,


        // level of logging
        // possible values: config.LOG_DISABLE || config.LOG_ERROR || config.LOG_WARN || config.LOG_INFO || config.LOG_DEBUG
        logLevel: config.LOG_DEBUG,


        // enable / disable watching file and executing tests whenever any file changes
        autoWatch: true,


        // start these browsers
        // available browser launchers: https://npmjs.org/browse/keyword/karma-launcher
        browsers: ['Firefox', 'PhantomJS'],


        // Continuous Integration mode
        // if true, Karma captures browsers, runs the tests and exits
        singleRun: true,

        // Concurrency level
        // how many browser should be started simultaneous
        concurrency: Infinity,

        junitReporter: {
            outputDir: './report_output/junit'
        },

        htmlReporter: {
            outputDir: './report_output/html'
        },

        coverageReporter: {
            type: 'html',
            dir: './report_output/coverage'
        },

        ngHtml2JsPreprocessor: {
            prependPrefix: '/',

            // - setting this option will create only a single module that contains templates
            //   from all the files, so you can load them all with module('foo')
            // - you may provide a function(htmlPath, originalPath) instead of a string
            //   if you'd like to generate modules dynamically
            //   htmlPath is a originalPath stripped and/or prepended
            //   with all provided suffixes and prefixes
            moduleName: 'directive.module'
        }
    })
}

