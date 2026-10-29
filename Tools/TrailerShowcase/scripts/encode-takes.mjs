import fs from 'node:fs';
import path from 'node:path';
import {fileURLToPath} from 'node:url';
import {spawnSync} from 'node:child_process';
const root=path.resolve(path.dirname(fileURLToPath(import.meta.url)),'..');
const project=path.resolve(root,'../..');
const names=process.argv.slice(2);
for(const name of names){
 if(!/^[a-z0-9-]+$/.test(name))throw Error('Invalid take name');
 const folder=path.join(project,'Temp/TrailerShowcase',name);
 const meta=JSON.parse(fs.readFileSync(path.join(folder,'take.json'),'utf8'));
 const files=fs.readdirSync(folder).filter(f=>/^\d{5}\.jpg$/.test(f));
 if(files.length!==meta.frames)throw Error(`${name}: ${files.length}/${meta.frames} frames`);
 const out=path.join(root,'public/takes',`${name}.mp4`);
 const args=['-hide_banner','-loglevel','error','-y','-framerate',String(meta.fps),'-i',path.join(folder,'%05d.jpg'),'-frames:v',String(meta.frames),'-c:v','libx264','-preset','fast','-crf','17','-pix_fmt','yuv420p','-movflags','+faststart',out];
 const r=spawnSync(process.env.FFMPEG||'ffmpeg',args,{stdio:'inherit'});if(r.status!==0)process.exit(r.status||1);
 fs.copyFileSync(path.join(folder,'take.json'),path.join(root,'docs',`${name}-take.json`));
 console.log(`${name}: ${meta.frames} native ${meta.fps}fps frames encoded`);
}
