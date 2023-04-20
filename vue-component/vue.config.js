var nodeExternals = require('webpack-node-externals');

module.exports = {
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
