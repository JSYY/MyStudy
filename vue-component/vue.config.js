var nodeExternals = require('webpack-node-externals');
const path = require('path');

module.exports = {
    pluginOptions: {
        'style-resources-loader': {
            preProcessor: 'less',
            // ������ patterns д�����ǿ��Ե�
            // patterns: ["./src/assets/reset1.less", "./src/assets/reset2.less"]
            // patterns: "./src/assets/reset.less"
            patterns: [
                // ����·��д�������ԣ������·������ʹ�� @ ���ţ�����ᱨ��
                // path.resolve(__dirname, './src/assets/reset.less')
                path.resolve(__dirname, 'src/assets/common.less')
            ]
        }
    },
    lintOnSave: false,
    outputDir: './modules/my-component/dist',
    productionSourceMap: false,
    css: { // ��һ�����ý�cssǿ�����������򷢲���������ʹ��ʱ����Я��css
        extract: false,
    },
    //���� webpack ��������ʾ
    configureWebpack: {
        performance: {
            hints: 'warning',
            //������������� �������ͣ����ֽ�Ϊ��λ��
            maxEntrypointSize: 50000000,
            //�����ļ��������� �������ͣ����ֽ�Ϊ��λ 300k��
            maxAssetSize: 30000000,
            //ֻ���� js �ļ���������ʾ
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
