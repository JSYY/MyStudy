/* eslint-disable no-console */

const exec = require('child_process').exec;
const merge2 = require('merge2');
const ts = require('gulp-typescript');
const gulp = require('gulp');
const rimraf = require('rimraf');
const tsConfigBase = require('../tsconfig.json');
const tsDefaultReporter = ts.reporter.defaultReporter();

const tsConfig = {
  target: 'es6',
  jsx: 'preserve',
  moduleResolution: 'node',
  declaration: true, // 生成类型定义
  sourceMap: true,
  allowSyntheticDefaultImports: true,
  ...tsConfigBase.compilerOptions
};

// 构建时，ts 配置
const destPath = tsConfig.outDir;

// 清除上次打包文件
function clean (done){
  rimraf.sync(destPath);
  done();
}

function compile() {
  let error = 0;
  const source = [
    '../src/**/*.js',
    '../src/**/*.jsx',
    '../src/**/*.tsx',
    '../src/**/*.ts',
    '!src/*/__tests__/*',
  ];

  const tsResult = gulp.src(source).pipe(
    ts(tsConfig, {
      error(e) {
        tsDefaultReporter.error(e);
        error = 1;
      },
      finish: tsDefaultReporter.finish,
    }),
  );

  function check() {
    if (error && !argv['ignore-error']) {
      process.exit(1);
    }
  }

  tsResult.on('finish', check);
  tsResult.on('end', check);
  const js = tsResult.js.pipe(gulp.dest(destPath));
  const tsd = tsResult.dts.pipe(gulp.dest(destPath));
  tsResult.js
  return merge2([js, tsd]);
}

function buildLib(){
  return exec(`npm run lib`, (err, stdout) => {
    console.log('info: ', stdout);
    console.error(err);
  })
}

// 配置对应的命令任务
exports.types = gulp.series(compile);
exports.buildLib = gulp.series(buildLib);
exports.default = gulp.series(clean, buildLib, compile);
