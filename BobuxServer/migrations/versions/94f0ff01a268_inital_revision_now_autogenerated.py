"""inital revision, now autogenerated

Revision ID: 94f0ff01a268
Revises: 
Create Date: 2020-10-14 13:45:21.695524

"""
from alembic import op
import sqlalchemy as sa

import bobuxserver

# revision identifiers, used by Alembic.
revision = '94f0ff01a268'
down_revision = None
branch_labels = None
depends_on = None


def upgrade():
    # ### commands auto generated by Alembic - please adjust! ###
    op.create_table('API',
    sa.Column('Key', bobuxserver.db.guid.GUID(), nullable=False),
    sa.Column('Secret', sa.String(length=64), nullable=False),
    sa.Column('Permissions', sa.Integer(), nullable=False),
    sa.Column('Created', sa.Integer(), nullable=False),
    sa.PrimaryKeyConstraint('Key')
    )
    op.create_table('User',
    sa.Column('UserId', sa.Integer(), autoincrement=True, nullable=False),
    sa.Column('SteamId', sa.String(length=20), nullable=True),
    sa.Column('DiscordId', sa.String(length=20), nullable=True),
    sa.Column('Bobux', sa.Integer(), nullable=False),
    sa.Column('TotalBobux', sa.Integer(), nullable=False),
    sa.PrimaryKeyConstraint('UserId')
    )
    # ### end Alembic commands ###


def downgrade():
    # ### commands auto generated by Alembic - please adjust! ###
    op.drop_table('User')
    op.drop_table('API')
    # ### end Alembic commands ###