import * as Action from '../actionTypes';

import _ from 'lodash';

const DEFAULT_MODELS = {
  users: {},
  user: {},

  favourites: {},

  equipmentList: {},
  equipment: {},
  equipmentPhysicalAttachments: {},
  equipmentSeniorityHistory: {},
  equipmentNotes: {},
  equipmentAttachments: {},
  equipmentHistory: {},

  owners: {},
  owner: {},
  ownerNotes: {},
  ownerAttachments: {},
  ownerHistory: {},

  projects: {},
  project: {},
  projectNotes: {},
  projectAttachments: {},
  projectHistory: {},

  rentalRequests: {},
  rentalRequest: {},
  rentalRequestNotes: {},
  rentalRequestAttachments: {},
  rentalRequestHistory: {},
  rentalRequestRotationList: {},

  rentalAgreement: {},
  rentalAgreementNotes: {},
  rentalAgreementHistory: {},
  rentalRate: {},
  rentalCondition: {},

  roles: {},
  role: {},
  rolePermissions: {},

  contacts: {},
  contact: {},

  documents: {},
  document: {},

  history: {},
};

export default function modelsReducer(state = DEFAULT_MODELS, action) {
  switch(action.type) {
    // Users
    case Action.UPDATE_USERS:
      return { ...state, users: action.users };

    case Action.UPDATE_USER:
      return { ...state, user: action.user };

    case Action.ADD_USER:
      return { ...state, user: action.user };

    case Action.DELETE_USER:
      return { ...state, user: action.user };

    // Favourites
    case Action.UPDATE_FAVOURITES:
      return { ...state, favourites: action.favourites };

    case Action.ADD_FAVOURITE:
      return { ...state, favourites: { ...state.favourites, ...action.favourite } };

    case Action.UPDATE_FAVOURITE:
      return { ...state, favourites: { ...state.favourites, ...action.favourite } };

    case Action.DELETE_FAVOURITE:
      return { ...state, favourites: _.omit(state.favourites, [ action.id ]) };

    // Contacts
    case Action.UPDATE_CONTACTS:
      return { ...state, contacts: action.contacts };

    case Action.ADD_CONTACT:
      return { ...state, contact: action.contact };

    case Action.UPDATE_CONTACT:
      return { ...state, contact: action.contact };

    case Action.DELETE_CONTACT:
      return { ...state, contact: action.contact };

    // Documents
    case Action.UPDATE_DOCUMENTS:
      return { ...state, documents: action.documents };

    case Action.ADD_DOCUMENT:
      return { ...state, document: action.document };

    case Action.UPDATE_DOCUMENT:
      return { ...state, document: action.document };

    case Action.DELETE_DOCUMENT:
      return { ...state, document: action.document };

    // Equipment
    case Action.UPDATE_EQUIPMENT_LIST:
      return { ...state, equipmentList: action.equipmentList };

    case Action.ADD_EQUIPMENT:
      return { ...state, equipment: action.equipment };

    case Action.UPDATE_EQUIPMENT:
      return { ...state, equipment: action.equipment };

    // Owners
    case Action.UPDATE_OWNERS:
      return { ...state, owners: action.owners };

    case Action.ADD_OWNER:
      return { ...state, owner: action.owner };

    case Action.UPDATE_OWNER:
      return { ...state, owner: action.owner };

    case Action.DELETE_OWNER:
      return { ...state, owner: action.owner };

    // Projects
    case Action.UPDATE_PROJECTS:
      return { ...state, projects: action.projects };

    case Action.ADD_PROJECT:
      return { ...state, project: action.project };

    case Action.UPDATE_PROJECT:
      return { ...state, project: action.project };

    // Rental Requests
    case Action.UPDATE_RENTAL_REQUESTS:
      return { ...state, rentalRequests: action.rentalRequests };

    case Action.ADD_RENTAL_REQUEST:
      return { ...state, rentalRequest: action.rentalRequest };

    case Action.UPDATE_RENTAL_REQUEST:
      return { ...state, rentalRequest: action.rentalRequest };

    // Rotation List
    case Action.UPDATE_RENTAL_REQUEST_ROTATION_LIST:
      return { ...state, rentalRequestRotationList: action.rentalRequestRotationList };

    // Rental Agreements
    case Action.ADD_RENTAL_AGREEMENT:
      return { ...state, rentalAgreement: action.rentalAgreement };

    case Action.UPDATE_RENTAL_AGREEMENT:
      return { ...state, rentalAgreement: action.rentalAgreement };

    // Rental Rates, Conditions
    case Action.ADD_RENTAL_RATE:
      return { ...state, rentalRate: action.rentalRate };

    case Action.UPDATE_RENTAL_RATE:
      return { ...state, rentalRate: action.rentalRate };

    case Action.DELETE_RENTAL_RATE:
      return { ...state, rentalRate: action.rentalRate };

    case Action.ADD_RENTAL_CONDITION:
      return { ...state, rentalCondition: action.rentalCondition };

    case Action.UPDATE_RENTAL_CONDITION:
      return { ...state, rentalCondition: action.rentalCondition };

    case Action.DELETE_RENTAL_CONDITION:
      return { ...state, rentalCondition: action.rentalCondition };

    // Roles, Permissions
    case Action.UPDATE_ROLES:
      return { ...state, roles: action.roles };

    case Action.ADD_ROLE:
      return { ...state, role: action.role };

    case Action.UPDATE_ROLE:
      return { ...state, role: action.role };

    case Action.DELETE_ROLE:
      return { ...state, role: action.role };

    case Action.UPDATE_ROLE_PERMISSIONS:
      return { ...state, rolePermissions: action.rolePermissions };

      // History
    case Action.UPDATE_HISTORY:
      return { ...state, history: action.history };
  }

  return state;
}
