from bobux.config import config

import asyncio
import websockets
from bobux.websockets.severlogic import processCommand

async def server(websocket, path):
    async for message in websocket:
        message = await processCommand(message, path)

ssl_context = ssl.SSLContext(ssl.PROTOCOL_TLS_SERVER)
ssl_context.load_cert_chain(config[certpath])
start_server = websockets.serve(
    hello, "localhost", 8765, ssl=ssl_context
)