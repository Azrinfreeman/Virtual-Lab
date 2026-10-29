import {delayRender,continueRender,cancelRender,staticFile} from 'remotion';
export const theme={width:1920,height:1080,fps:60,total:3600,bpm:96,colors:{base:'#14103F',raised:'#221C5C',paper:'#F6F1E4',text:'#F4F2FF',secondary:'#C9C4EE',info:'#5CC8FF'},font:'Liberation, Arial, sans-serif'} as const;
const handle=delayRender('Load project fonts');
Promise.all([
  new FontFace('Liberation',`url("${staticFile('brand/LiberationSans.ttf')}")`).load(),
  new FontFace('PurpleSmile',`url("${staticFile('brand/PurpleSmile.ttf')}")`).load(),
]).then(fonts=>{fonts.forEach(f=>document.fonts.add(f));continueRender(handle);}).catch(error=>cancelRender(error));
