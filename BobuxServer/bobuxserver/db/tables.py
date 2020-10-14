from sqlalchemy import MetaData, Column, Table
from sqlalchemy import Integer, String
from sqlalchemy.ext.declarative import declarative_base
from bobuxserver.db import guid

Base = declarative_base()

class User(Base):
        __tablename__ = 'User'
        userId = Column('UserId', Integer, primary_key=True, autoincrement=True)
        steamId = Column('SteamId', String(20), nullable=True)
        discordId = Column('DiscordId', String(20), nullable=True)
        bobux = Column('Bobux', Integer, nullable=False)
        totalBobux = Column('TotalBobux', Integer, nullable=False)

class API(Base):
        __tablename__ = 'API'
        key = Column('Key', guid.GUID, primary_key=True)
        secret = Column('Secret', String(64), nullable=False)
        permissions = Column('Permissions', Integer, nullable=False)
        created = Column('Created', Integer, nullable=False)
