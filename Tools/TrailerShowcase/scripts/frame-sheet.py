from pathlib import Path
from PIL import Image,ImageDraw
root=Path(__file__).resolve().parents[1]
frames=sorted((root/'out/qa/frames').glob('*.png'))
sheet=Image.new('RGB',(1440,291*((len(frames)+2)//3)),'#14103F')
d=ImageDraw.Draw(sheet)
for i,p in enumerate(frames):
    im=Image.open(p);im.thumbnail((480,270));x=i%3*480;y=i//3*291
    sheet.paste(im,(x,y));d.text((x+10,y+273),f'Frame {int(p.stem)} / {int(p.stem)/60:.2f}s',fill='#F4F2FF')
sheet.save(root/'out/qa/composition-sheet.jpg',quality=90)
print('Composed-frame contact sheet saved.')
