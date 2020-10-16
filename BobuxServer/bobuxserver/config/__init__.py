import yaml

config = yaml.load(open("bobuxserver.yaml", 'r'))

requiredParams = [
    'dbpath', #bobuxserver.db
    'certpath' #bobuxserver.websockets
]

for i in requiredParams:
    if not (i in config):
        raise KeyError("Config value " + i + " was not found.")
