"""initial create

Revision ID: a71d022e22b4
Revises: 
Create Date: 2020-09-22 15:14:16.534319

"""
from alembic import op
import sqlalchemy as sa


# revision identifiers, used by Alembic.
revision = 'a71d022e22b4'
down_revision = None
branch_labels = None
depends_on = None


def upgrade():
    op.create_table(
        'Users',
        sa.Column('UserId', sa.Integer, primary_key=True, autoincrement=True),
        sa.Column('SteamId', sa.String(20), nullable=True),
        sa.Column('DiscordId', sa.String(20), nullable=True),
        sa.Column('Bobux', sa.Integer, nullable=False),
        sa.Column('TotalBobux', sa.Integer, nullable=False)
    )

def downgrade():
    op.drop_table('Users')