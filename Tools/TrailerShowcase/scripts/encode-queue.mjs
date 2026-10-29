import fs from 'node:fs';
import {spawnSync} from 'node:child_process';
const marker='../../Temp/TrailerShowcase/queue-complete.txt';
const start=Date.now();
while(!fs.existsSync(marker)){
 if(Date.now()-start>15*60*1000)throw Error('Capture queue did not finish in 15 minutes. Inspect Unity console before retry.');
 await new Promise(resolve=>setTimeout(resolve,2000));
}
const result=spawnSync(process.execPath,['scripts/encode-takes.mjs','overview','menu','transfer','observation','vitamin','anatomy','plate','quiz'],{stdio:'inherit'});
process.exitCode=result.status??1;
