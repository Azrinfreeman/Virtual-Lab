export const beatF=(beat:number)=>Math.round(beat*60*60/96);
export type Shot={id:string;startFrame:number;durationInFrames:number;narrativeGoal:string;visual:string;motion:string;audio:string;assetRefs:string[];caption:string;disclosure?:string;sourceStart?:number};
export const SHOTS:Record<string,Shot>={
  hook:{id:'hook',startFrame:beatF(0),durationInFrames:beatF(8),narrativeGoal:'Enter the virtual laboratory',visual:'Native bench tracking',motion:'Slow eased native camera reveal',audio:'Curious opening',assetRefs:['takes/overview.mp4'],caption:'Terokai nutrisi dalam makmal maya.'},
  menu:{id:'menu',startFrame:beatF(8),durationInFrames:beatF(8),narrativeGoal:'Eight activity choices',visual:'Current menu and activity selection',motion:'Native focus and click',audio:'Game selection cue',assetRefs:['takes/menu.mp4'],caption:'8 aktiviti. Pelbagai penemuan.'},
  transfer:{id:'transfer',startFrame:beatF(16),durationInFrames:beatF(16),narrativeGoal:'Demonstrate the experiment mechanism',visual:'Authored transfer demonstration',motion:'Native apparatus animation',audio:'Score supports the demonstration',assetRefs:['takes/transfer.mp4'],caption:'Ikuti eksperimen langkah demi langkah.',disclosure:'Petikan animasi simulasi'},
  observation:{id:'observation',startFrame:beatF(32),durationInFrames:beatF(12),narrativeGoal:'Observe a scientific change',visual:'Authored iodine observation insert',motion:'Native animation at original speed',audio:'Lower-energy breathing space',assetRefs:['takes/observation.mp4'],caption:'Perhati perubahan. Fahami tindak balas.',disclosure:'Petikan animasi simulasi · langkah sebelumnya dipendekkan'},
  vitamin:{id:'vitamin',startFrame:beatF(44),durationInFrames:beatF(12),narrativeGoal:'A distinct mechanism',visual:'Vitamin C syringe simulation',motion:'Native animation at original speed',audio:'Pulse returns',assetRefs:['takes/vitamin.mp4'],caption:'Bandingkan. Buat kesimpulan.',disclosure:'Petikan animasi simulasi · langkah sebelumnya dipendekkan'},
  anatomy:{id:'anatomy',startFrame:beatF(56),durationInFrames:beatF(8),narrativeGoal:'Understand the digestive system',visual:'Actual labelled anatomy view',motion:'Readable hold and native view selection',audio:'Light transition',assetRefs:['takes/anatomy.mp4'],caption:'Kenali sistem pencernaan.'},
  plate:{id:'plate',startFrame:beatF(64),durationInFrames:beatF(12),narrativeGoal:'Act on healthy food choices',visual:'Real drag/drop path',motion:'One deliberate food placement',audio:'Actual game insertion cue',assetRefs:['takes/plate.mp4'],caption:'Susun pinggan sihat anda.'},
  quiz:{id:'quiz',startFrame:beatF(76),durationInFrames:beatF(12),narrativeGoal:'End gameplay on verified answer feedback',visual:'Real toggles and first-question check',motion:'Three deliberate choices, then hold Betul',audio:'Actual game click cues',assetRefs:['takes/quiz.mp4'],caption:'Uji kefahaman anda.'},
  brand:{id:'brand',startFrame:beatF(88),durationInFrames:beatF(8),narrativeGoal:'Remember the project',visual:'Original logo, wordmark, motto',motion:'Shotcraft shrink and lockup',audio:'Original brand sound and resolution',assetRefs:['brand/logo.png'],caption:'Belajar. Eksperimen. Fahami.'},
};
export const SFX=[
 {from:SHOTS.menu.startFrame+270,duration:20,src:'audio/game-click.mp3',volume:.48,reason:'Real activity button pointerClick'},
 {from:SHOTS.plate.startFrame+221,duration:20,src:'audio/game-click.mp3',volume:.38,reason:'Accepted food placement'},
 ...[90,150,210].map(offset=>({from:SHOTS.quiz.startFrame+offset,duration:20,src:'audio/game-click.mp3',volume:.32,reason:'Real toggle choice'})),
 {from:SHOTS.brand.startFrame,duration:90,src:'audio/brand-rise.wav',volume:.65,reason:'Original gentle closing riser'},
 {from:SHOTS.brand.startFrame+74,duration:100,src:'audio/brand-land.wav',volume:.72,reason:'Contraction brake at t=.28'},
];
