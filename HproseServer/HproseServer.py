from shapely.geometry import Polygon
import hprose

def getOverloapArea(param_hexagon1:str,param_hexagon2:str):
    hexagon1=Polygon(stringToArray(param_hexagon1))
    hexagon2=Polygon(stringToArray(param_hexagon2))
    return str(hexagon1.intersection(hexagon2).area)

def getArea(param_hexagon:str):
    hexagon=Polygon(stringToArray(param_hexagon))
    return str(hexagon.area)

def isOverloap(param_hexagon1:str,param_hexagon2:str):
    hexagon1=Polygon(stringToArray(param_hexagon1))
    hexagon2=Polygon(stringToArray(param_hexagon2))
    return str(hexagon1.intersects(hexagon2))

def stringToArray(s:str):
    nums=s.split("/")
    result=[]
    for pairs in nums:
        t=pairs.split(",")
        result.append((float(t[0]),float(t[1])))
    return result


def main():
    server = hprose.HttpServer(port = 8082)
    server.addFunction(getArea)
    server.addFunction(getOverloapArea)
    server.addFunction(isOverloap)
    server.start()



if __name__ == '__main__':
    main()