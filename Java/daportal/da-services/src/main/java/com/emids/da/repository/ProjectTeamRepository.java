package com.emids.da.repository;

import com.emids.da.model.ProjectTeam;
import com.emids.da.repository.AbstractRepository;
import com.google.inject.persist.Transactional;

@Transactional
public class ProjectTeamRepository extends AbstractRepository<ProjectTeam> {

  @Override
  public ProjectTeam findById(Long id) {
    return find(ProjectTeam.class, id);
  }
}
