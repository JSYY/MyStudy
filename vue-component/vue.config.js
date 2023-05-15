var nodeExternals = require('webpack-node-externals');
const path = require('path');

module.exports = {
    pluginOptions: {
        'style-resources-loader': {
            preProcessor: 'less',
            // 这三种 patterns 写法都是可以的
            // patterns: ["./src/assets/reset1.less", "./src/assets/reset2.less"]
            // patterns: "./src/assets/reset.less"
            patterns: [
                // 两种路径写法都可以，这里的路径不能使用 @ 符号，否则会报错
                // path.resolve(__dirname, './src/assets/reset.less')
                path.resolve(__dirname, 'src/assets/common.less')
            ]
        }
    },
    lintOnSave: false,
    outputDir: './modules/my-component/dist',
    productionSourceMap: false,
    css: { // 这一步配置将css强行内联，否则发布后的组件在使用时不会携带css
        extract: false,
    },
    //警告 webpack 的性能提示
    configureWebpack: {
        performance: {
            hints: 'warning',
            //入口起点的最大体积 整数类型（以字节为单位）
            maxEntrypointSize: 50000000,
            //生成文件的最大体积 整数类型（以字节为单位 300k）
            maxAssetSize: 30000000,
            //只给出 js 文件的性能提示
            assetFilter: function (assetFilename) {
                return assetFilename.endsWith('.js');
            }
        },
        mode: 'development',
        externals: [nodeExternals(
            {
                additionalModuleDirs: ['./node_modules/']
            })]
    }
}
