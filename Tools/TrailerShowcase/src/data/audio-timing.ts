// Measured: Remotion4.0.539, H.264/AAC48k stereo MP4, 60fps; three click probes.
// Keep source peak analysis separate from codec output delay.
export const OUTPUT_AUDIO_OFFSET_F=1.38125;
export const SOURCE_PEAK_F:Record<string,number>={'audio/game-click.mp3':.495,'audio/brand-land.wav':.24875};
export const audioFrom=(targetFrame:number,src:string)=>Math.max(0,Math.round(targetFrame-(SOURCE_PEAK_F[src]??0)-OUTPUT_AUDIO_OFFSET_F));
