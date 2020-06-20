const merge = require('webpack-merge');
const basecfg = require('./webpack.config.base.js');

module.exports = merge(basecfg, {
  mode: 'production',
});
