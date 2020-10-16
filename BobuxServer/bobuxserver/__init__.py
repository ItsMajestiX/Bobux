from bobux.websockets import start_server

import asyncio

def start():
    asyncio.get_event_loop().run_until_complete(start_server)
    asyncio.get_event_loop().run_forever()