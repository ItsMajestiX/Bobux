from sqlalchemy import create_engine
from sqlalchemy.orm import sessionmaker
from bobuxserver.db.tables import Base

engine = create_engine()
Base.metadata.create_all(engine)

def createSession():
    return sessionmaker(bind=engine)