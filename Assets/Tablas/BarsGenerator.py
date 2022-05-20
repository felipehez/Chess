import csv
import bpy

newBarPos = 0
blueMat = bpy.data.materials.get("Blue") 
blackMat = bpy.data.materials.get("Black")
whiteMat = bpy.data.materials.get("White")
redMat = bpy.data.materials.get("Red")


with open('C:/Unity/Games/Chess/Assets/Tablas/ProgramacionData.csv') as f:
    readout = list(csv.reader(f))

for a in readout:
    
    placement = readout.index(a)
    barSize = float(a[2])
    bpy.ops.mesh.primitive_plane_add(size=1, location=(newBarPos, 0, 0))
    new_bar = bpy.context.object
    
    #displace vertices to level pivot
    for vert in new_bar.data.vertices:
        vert.co[0] += 0.5
    #bar Size
    new_bar.scale = (barSize,1,1)
    
    #asign material
    new_bar.data.materials.append(blueMat)
    
    #add text
    bpy.ops.object.text_add(enter_editmode=False, location=(newBarPos+0.2, 0, 0))
    bpy.context.object.data.align_y = 'CENTER'
    bpy.context.object.data.body = a[1]
    bpy.context.object.data.size = 0.8
    
    #add separator bar
    bpy.ops.mesh.primitive_plane_add(size=1, location=(newBarPos, 0, 0))
    sepBar = bpy.context.object
    sepBar.scale = (0.1,1,1)
    sepBar.data.materials.append(whiteMat)

    #new_bar.data.materials[0] = blueMat
        
    newBarPos += barSize
