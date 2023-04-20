var nodeExternals = require('webpack-node-externals');

module.exports = {
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
