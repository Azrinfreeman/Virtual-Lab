from pathlib import Path
from PIL import Image,ImageDraw
import json
root=Path(__file__).resolve().parents[1]
raw=root.parents[1]/'Temp/TrailerShowcase'
out=root/'out/qa/takes'
out.mkdir(parents=True,exist_ok=True)
names=['overview','menu','transfer','observation','vitamin','anatomy','plate','quiz']
for name in names:
    meta=json.loads((raw/name/'take.json').read_text())
    sheet=Image.new('RGB',(1440,873),'#14103F');d=ImageDraw.Draw(sheet)
    for j in range(9):
        f=round(j*(meta['frames']-1)/8)
        im=Image.open(raw/name/f'{f:05d}.jpg');im.thumbnail((480,270))
        x=(j%3)*480;y=(j//3)*291
        sheet.paste(im,(x,y));d.text((x+10,y+273),f'{name} / frame{f}',fill='#F4F2FF')
    sheet.save(out/f'{name}.jpg',quality=90)
print('Eight take sheets created, nine native source frames each.')
